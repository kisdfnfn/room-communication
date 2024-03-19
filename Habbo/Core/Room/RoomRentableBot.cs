using Habbo.Messages.Incoming;

namespace Habbo.Core.Room
{
  class RoomRentableBot : RoomUnit
  {
    public string Gender = "";
    public int OwnerId = -1;
    public string OwnerName = "";
    List<short> Skills = new List<short>();

    public RoomRentableBot()
    {
    }

    public new void Parse(IncomingPacket packet)
    {
      Gender = packet.GetString();
      OwnerId = packet.GetInt();
      Gender = packet.GetString();
      int count = packet.GetInt();
      for (var i = 0; i < count; i++)
      {
        Skills.Add(packet.GetShort());
      }
    }

  }
}
