namespace Habbo.Messages.Outgoing.Rooms.Users
{
  class RoomUserTalkComposer : OutgoingPacket
  {

    public RoomUserTalkComposer(string message, int bubbleStyle, int messagesSendCount) : base(OutgoingHeaders.RoomUserTalk)
    {
      AddString(message);
      AddInt(bubbleStyle);
      AddInt(messagesSendCount);
    }

  }
}
// " "