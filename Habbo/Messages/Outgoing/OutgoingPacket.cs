namespace Habbo.Messages.Outgoing
{
  public class OutgoingPacket : PacketWriter
  {

    public OutgoingPacket(short header)
    {
      AddInt(0);
      AddShort(header);
    }

    public byte[] Compose()
    {
      Reset();
      AddInt(data.Count() - 4);
      return data.ToArray();
    }

  }
}