using Habbo.Messages.Incoming;

namespace Habbo.Core.Room
{
  class RoomUser : RoomUnit
  {
    public string Gender = "";
    public int GroupID = -1;
    public int GroupStatus = -1;
    public string GroupName = "";
    public int ActivityPoints = -1;
    public bool IsModerator = false;

    public RoomUser()
    {
    }

    public override void Parse(IncomingPacket packet)
    {
      Gender = packet.GetString();
      GroupID = packet.GetInt();
      GroupStatus = packet.GetInt();
      GroupName = packet.GetString();

      packet.GetString(); // Swim Figure

      ActivityPoints = packet.GetInt();
      IsModerator = packet.GetBool();

      // Console.WriteLine($"Gender: {Gender}\nGroupID: {GroupID}\nGroupStatus: {GroupStatus}\nGroupName: {GroupName}\nActivityPoints: {ActivityPoints}\nIsModerator: {IsModerator}");
    }

  }
}
