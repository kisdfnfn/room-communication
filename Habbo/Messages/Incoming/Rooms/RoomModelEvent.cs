namespace Habbo.Messages.Incoming.Rooms
{
  class RoomModelEvent : IncomingPacket
  {
    public string LayoutName;
    public int Id;

    public RoomModelEvent(byte[] data) : base(data)
    {
      LayoutName = GetString();
      Id = GetInt();
    }

  }
}
