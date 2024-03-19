namespace Habbo.Messages.Outgoing.Handshake
{
  class ReleaseVersionComposer : OutgoingPacket
  {

    public ReleaseVersionComposer(string production, string type, int platform, int category) : base(OutgoingHeaders.ReleaseVersion)
    {
      AddString(production);
      AddString(type);
      AddInt(platform);
      AddInt(category);
    }

  }
}
