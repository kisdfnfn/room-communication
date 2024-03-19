namespace Habbo.Messages.Incoming.Rooms
{
  public class RoomPaintEvent : IncomingPacket
  {
    public string Type;
    public string Value;

    public RoomPaintEvent(byte[] data) : base(data)
    {
      Type = GetString();
      Value = GetString();
    }

  }
}
