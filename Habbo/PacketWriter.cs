using System.Text;

namespace Habbo
{
  public class PacketWriter
  {
    protected List<byte> data = new List<byte>();
    int offset = 0;

    public PacketWriter()
    {
    }

    public void AddInt(int value)
    {
      if (offset + 4 >= data.Count)
      {
        data.AddRange(new byte[offset + 4 - data.Count]);
      }
      data[offset++] = (byte)((value >> 24) & 0xFF);
      data[offset++] = (byte)((value >> 16) & 0xFF);
      data[offset++] = (byte)((value >> 8) & 0xFF);
      data[offset++] = (byte)(value & 0xFF);
    }

    public void AddShort(short value)
    {
      if (offset + 2 > data.Count)
      {
        data.AddRange(new byte[offset + 2 - data.Count]);
      }
      data[offset++] = (byte)((value >> 8) & 0xFF);
      data[offset++] = (byte)(value & 0xFF);
    }

    public void AddString(string value)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(value, 0, value.Length);

      short length = 0;
      if (bytes.Length > short.MaxValue)
      {
        length = short.MaxValue;
      }
      else
      {
        length = (short)bytes.Length;
      }
      AddShort(length);

      data.AddRange(bytes);
      offset += bytes.Length;
    }

    public void AddBool(bool value)
    {
      if (offset + 1 > data.Count)
      {
        data.Add(0);
      }
      data[offset++] = (byte)(value ? 1 : 0);
    }

    public void Reset()
    {
      offset = 0;
    }

  }
}