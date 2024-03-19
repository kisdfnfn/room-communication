using System.Text;

namespace Habbo
{
    public class PacketReader
    {
        byte[] data;
        int offset;

        public PacketReader(byte[] data)
        {
            this.data = data;
        }

        public int GetInt()
        {
            return
                (data[offset++] << 24) |
                (data[offset++] << 16) |
                (data[offset++] << 8) |
                data[offset++];
        }

        public short GetShort()
        {
            return (short)((data[offset++] << 8) | data[offset++]);
        }

        public short PeekShort()
        {
            return (short)((data[offset] << 8) | data[offset + 1]);
        }

        public string GetString()
        {
            short length = GetShort();
            string str = Encoding.UTF8.GetString(data, offset, length);
            offset += length;
            return str;
        }

        public bool GetBool()
        {
            return data[offset++] != 0;
        }
    }
}