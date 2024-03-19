using System.Net;
using System.Net.Sockets;
using Habbo.Messages.Outgoing;
using Habbo.Messages.Incoming;
using System.Reflection;

namespace Habbo
{
  public delegate void HabboEventCallback<T>(T ev);

  public class HabboProtocol
  {
    public static String policy = "<?xml version=\"1.0\"?>\n" +
        "  <!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\n" +
        "  <cross-domain-policy>\n" +
        "  <allow-access-from domain=\"*\" to-ports=\"*\" />\n" +
        "  </cross-domain-policy>\0";

    HabboClient client;
    Dictionary<Type, List<Delegate>> events = new Dictionary<Type, List<Delegate>>();
    public IncomingManager incomingManager = new IncomingManager();
    Socket socket;
    byte[] IncompletedData = new byte[0];

    public HabboProtocol(IPEndPoint ipEndPoint)
    {
      socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      socket.Connect(ipEndPoint);

      client = new HabboClient(this);

      Task.Factory.StartNew(() =>
      {
        try
        {
          while (true)
          {
            byte[] buffer = new byte[1_024];
            int len = socket.Receive(buffer, SocketFlags.None);

            if (len == 0)
            {
              Console.WriteLine("Closed.");
              break;
            }

            IncompletedData = IncompletedData.Concat(buffer.Take(len)).ToArray();

            while (IncompletedData.Length >= 4)
            {
              PacketReader reader = new PacketReader(IncompletedData);
              int length = reader.GetInt() + 4;

              if (length > IncompletedData.Length) break;

              byte[] data = IncompletedData.Take(length).ToArray();
              IncompletedData = IncompletedData.Skip(length).ToArray();

              short header = reader.GetShort();
              // Console.WriteLine(header);
              IncomingPacket? ev = incomingManager.GetEvent(header, data);

              if (ev != null)
              {
                // Console.WriteLine($"Header: {header}");
                MethodInfo? method = typeof(HabboProtocol).GetMethod("DispatchEvent")?.MakeGenericMethod(ev.GetType());
                method?.Invoke(this, new object[] { ev, client });
              }
              else
              {
                // Console.WriteLine($"Unknown Header: {header}");
              }
            }
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      });
    }

    public void Dispose()
    {
      socket?.Close();
    }

    public void ListenEvent<T>(Action<T, HabboClient> cb) where T : IncomingPacket
    {
      if (!events.ContainsKey(typeof(T)))
      {
        events[typeof(T)] = new List<Delegate>();
      }
      events[typeof(T)].Add(cb);
    }

    public void ListenEventOnce<T>(Action<T, HabboClient> cb) where T : IncomingPacket
    {
      if (!events.ContainsKey(typeof(T)))
      {
        events[typeof(T)] = new List<Delegate>();
      }
      Action<T, HabboClient>? cbProxy = null;
      cbProxy = (T ev, HabboClient client) =>
      {
        cb(ev, client);
        events[typeof(T)].Remove(cbProxy!);
      };
      events[typeof(T)].Add(cbProxy);
    }

    public Task<T> ListenEventAsync<T>() where T : IncomingPacket
    {
      var taskCompletion = new TaskCompletionSource<T>();
      ListenEventOnce<T>((T ev, HabboClient client) =>
      {
        taskCompletion.SetResult(ev);
      });
      return taskCompletion.Task;
    }

    public void DispatchEvent<T>(T ev, HabboClient client) where T : IncomingPacket
    {
      if (events.ContainsKey(typeof(T)))
      {
        Delegate[] delegates = events[typeof(T)].Take(events[typeof(T)].Count).ToArray();
        // List<Action<T, HabboClient>> delegates = new List<Action<T, HabboClient>>();
        // foreach (Action<T, HabboClient> callback in events[typeof(T)])
        // {
        //   delegates.Add(callback);
        // }
        try
        {
          foreach (Action<T, HabboClient> callback in delegates)
          {
            callback(ev, client);
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      }
    }

    public void Send(OutgoingPacket packet)
    {
      socket?.Send(packet.Compose());
    }
  }
}