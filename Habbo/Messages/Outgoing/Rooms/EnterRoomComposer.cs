namespace Habbo.Messages.Outgoing.Rooms
{
  class EnterRoomComposer : OutgoingPacket
  {

    public EnterRoomComposer(int roomId, string password) : base(OutgoingHeaders.EnterRoom)
    {
      AddInt(roomId);
      AddString(password);
    }

  }
}
