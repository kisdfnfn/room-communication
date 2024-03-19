namespace Habbo.Messages.Outgoing.Handshake
{
  class PongComposer : OutgoingPacket
  {

    public PongComposer() : base(OutgoingHeaders.Pong)
    {
    }

  }
}
