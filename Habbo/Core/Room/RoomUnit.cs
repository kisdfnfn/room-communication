using Habbo.Core.Math;
using Habbo.Messages.Incoming;

namespace Habbo.Core.Room
{
  public class RoomUnit
  {
    public int Id = -1;
    public string Username = "";
    public string Motto = "";
    public string Figure = "";
    public int RoomIndex = -1;
    public Vector Position = new Vector();
    public int BodyRotation = -1;

    public RoomUnit()
    {
    }

    public virtual void Parse(IncomingPacket packet) {}

  }
}
