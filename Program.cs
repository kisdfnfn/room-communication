using System.Net;
using Habbo;
using Habbo.Messages.Outgoing.Handshake;
using Habbo.Messages.Outgoing.Rooms.Users;
using Habbo.Messages.Incoming.Rooms.Users;
using Habbo.Messages.Incoming.Handshake;

void HandshakeSuccess(HandshakeSuccessEvent ev, HabboClient client) {
  client.EnterRoom(6188424);
}

void RoomUserTalk(RoomUserTalkEvent ev, HabboClient client)
{
  var unit = client.GetRoom()?.GetUnitByRoomIndex(ev.RoomIndex);
  if (unit == null) return;

  if (ev.Message.ToLower().StartsWith(client.GetUsername().ToLower()))
  {
    client.Protocol.Send(new RoomUserTalkComposer(":handitem 1", 0, 0));
    client.Protocol.Send(new RoomUserTalkComposer($"Coé {unit.Username}!", 0, 0));
  }
}

Console.Write("SSO > ");
string ssoTicket = Console.ReadLine() ?? "0";

// 144.217.125.146:4431
IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("proxy.habblet.city");
IPAddress ipAddress = ipHostInfo.AddressList[0];
IPEndPoint ipEndPoint = new(ipAddress, 30_000);
HabboProtocol hp = new HabboProtocol(ipEndPoint);

Console.WriteLine("Ready.");

hp.Send(new ReleaseVersionComposer("PRODUCTION-202101271337-HTML5", "HTML5", 2, 1));
hp.Send(new MachineIDComposer());
hp.Send(new SecureLoginComposer(ssoTicket));

hp.ListenEvent<RoomUserTalkEvent>(RoomUserTalk);
hp.ListenEvent<HandshakeSuccessEvent>(HandshakeSuccess);

// {h:2941}{i:5117323}


Console.ReadLine();