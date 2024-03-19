namespace Habbo.Messages.Outgoing.Handshake
{
  class UsernameComposer : OutgoingPacket
  {

    public UsernameComposer(string username) : base(OutgoingHeaders.Username)
    {
      AddString(username);
    }

  }
}
