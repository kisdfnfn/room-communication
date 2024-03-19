using Habbo.Messages.Incoming.Handshake;
using Habbo.Messages.Incoming.Users;
using Habbo.Messages.Incoming.Rooms;
using Habbo.Messages.Incoming.Rooms.Users;
using Habbo.Messages.Outgoing.Rooms;
using Habbo.Messages.Outgoing.Handshake;
using Habbo.Messages.Outgoing.Users;
using Habbo.Core.Room;

namespace Habbo
{
  public class HabboClient
  {
    int Id = -1;
    string Username = "";
    string Figure = "";
    string Gender = "";
    string Motto = "";
    int RespectPointsReceived = -1;
    int RespectPointsToGive = -1;
    int PetRespectPointsToGive = -1;
    Room? Room = null;

    public HabboProtocol Protocol;

    public HabboClient(HabboProtocol protocol)
    {
      Protocol = protocol;
      Protocol.ListenEvent<HandshakeSuccessEvent>(HandshakeSuccess);
      Protocol.ListenEvent<UserDataEvent>(UserData);
      Protocol.ListenEvent<PingEvent>(Ping);
      Protocol.ListenEvent<RoomUsersEvent>(RoomUsers);
      Protocol.ListenEvent<RoomRightsEvent>(RoomRights);
      Protocol.ListenEvent<RoomOpenEvent>(RoomOpen);
    }

    void HandshakeSuccess(HandshakeSuccessEvent ev, HabboClient client)
    {
      Protocol.Send(new RequestUserDataComposer());
    }

    void UserData(UserDataEvent ev, HabboClient client)
    {
      Id = ev.Id;
      Username = ev.Username;
      Figure = ev.Figure;
      Gender = ev.Gender;
      Motto = ev.Motto;
      RespectPointsReceived = ev.RespectPointsReceived;
      RespectPointsToGive = ev.RespectPointsToGive;
      PetRespectPointsToGive = ev.PetRespectPointsToGive;

      // Protocol.Send(new UsernameComposer(Username));
    }

    void Ping(PingEvent ev, HabboClient client)
    {
      Console.WriteLine("Ping");
      Protocol.Send(new PongComposer());
    }

    void RoomUsers(RoomUsersEvent ev, HabboClient client)
    {
      if (Room == null)
      {
        Console.WriteLine("[WARN]: Receive room users from server but the Room Object isn't created.");
        return;
      }
      foreach (RoomUnit unit in ev.units)
      {
        Room.Units.Add(unit);
      }
    }

    void RoomRights(RoomRightsEvent ev, HabboClient client)
    {
      if (Room == null) return;
      Console.WriteLine("RoomRights");
      Protocol.Send(new RoomModelComposer());
    }

    void RoomOpen(RoomOpenEvent ev, HabboClient client)
    {
      Console.WriteLine("RoomOpen");
      Room = new Room();
    }

    public RoomUnit? GetRoomUnit()
    {
      return Room?.GetUnitByUsername(Username);
    }

    public void EnterRoom(int id, string password = "")
    {
      Protocol.Send(new EnterRoomComposer(id, password));
      // RoomOpenEvent roomOpenEv = await Protocol.ListenEventAsync<RoomOpenEvent>();
      // RoomModelEvent roomModel = await Protocol.ListenEventAsync<RoomModelEvent>();

      // RoomPaintEvent roomPaint1 = await Protocol.ListenEventAsync<RoomPaintEvent>();
      // RoomPaintEvent roomPaint2 = await Protocol.ListenEventAsync<RoomPaintEvent>();
      // RoomPaintEvent roomPaint3 = await Protocol.ListenEventAsync<RoomPaintEvent>();

      // RoomScoreEvent roomScore = await Protocol.ListenEventAsync<RoomScoreEvent>();
      // RoomRelativeMapEvent roomRelativeMap = await Protocol.ListenEventAsync<RoomRelativeMapEvent>();

      Console.WriteLine("Loaded");
    }

    public Room? GetRoom()
    {
      return Room;
    }

    public string GetUsername() {
      return Username;
    }

  }
}
