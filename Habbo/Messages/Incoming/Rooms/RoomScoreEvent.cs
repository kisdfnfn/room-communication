namespace Habbo.Messages.Incoming.Rooms
{
  class RoomScoreEvent : IncomingPacket
  {
    public int Score;
    public bool CanVote;

    public RoomScoreEvent(byte[] data) : base(data)
    {
      Score = GetInt();
      CanVote = GetBool();
    }

  }
}
