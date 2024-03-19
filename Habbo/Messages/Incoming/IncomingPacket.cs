namespace Habbo.Messages.Incoming
{
  public class IncomingPacket : PacketReader
  {
    public readonly int Size;
    public readonly short Header;

    public IncomingPacket(byte[] data) : base(data)
    {
      Size = GetInt();
      Header = GetShort();
    }

  }
}