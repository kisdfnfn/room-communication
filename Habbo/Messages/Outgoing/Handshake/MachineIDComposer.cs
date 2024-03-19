namespace Habbo.Messages.Outgoing.Handshake
{
  class MachineIDComposer : OutgoingPacket
  {

    public MachineIDComposer() : base(OutgoingHeaders.MachineID)
    {
      AddString("");
      AddString("UIID-936726677");
    }

  }
}
