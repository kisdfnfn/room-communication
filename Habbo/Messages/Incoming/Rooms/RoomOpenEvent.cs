using System;

namespace Habbo.Messages.Incoming.Rooms
{
  class RoomOpenEvent : IncomingPacket
  {

    public RoomOpenEvent(byte[] data) : base(data)
    {
    }

  }
}
