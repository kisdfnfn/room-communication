using System;

namespace Habbo.Messages.Incoming.Rooms.Users
{
  class RoomUserTalkEvent : IncomingPacket
  {
    public int RoomIndex;
    public string Message;
    public int Emotion;
    public int BubbleStyle;

    public RoomUserTalkEvent(byte[] data) : base(data)
    {
      RoomIndex = GetInt();
      Message = GetString();
      Emotion = GetInt();
      BubbleStyle = GetInt();
      GetInt(); // ??
      GetInt(); // Message Length
    }

  }
}
