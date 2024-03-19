using System;

namespace Habbo.Messages.Incoming.Handshake
{
  class PingEvent : IncomingPacket
  {

    public PingEvent(byte[] data) : base(data)
    {
    }

  }
}
