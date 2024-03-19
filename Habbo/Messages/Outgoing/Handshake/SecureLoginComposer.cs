namespace Habbo.Messages.Outgoing.Handshake
{
  class SecureLoginComposer : OutgoingPacket
  {

    public SecureLoginComposer(string sso) : base(OutgoingHeaders.SecureLogin)
    {
      AddString(sso);
      AddInt(0x317b);
      AddString(Crypt(sso));
    }

    public static string Crypt(string e)
    {
      Func<char, int> t = (char c) => "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".IndexOf(c);

      return new string(e.Select((char c) =>
      {
        int index = t(c);
        return index > -1 ? "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm"[index] : c;
      }).ToArray());
    }

  }
}
