namespace Habbo.Messages.Incoming.Rooms
{
  class RoomRelativeMapEvent : IncomingPacket
  {
    public int Width;
    public int TotalTiles;
    public List<short> HeightMap = new List<short>();

    public RoomRelativeMapEvent(byte[] data) : base(data)
    {
      Width = GetInt();
      TotalTiles = GetInt();
      for (var i = 0; i < TotalTiles; i++)
      {
        HeightMap.Add(GetShort());
      }
    }

  }
}
