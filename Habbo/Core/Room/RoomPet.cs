using Habbo.Messages.Incoming;

namespace Habbo.Core.Room
{
  class RoomPet : RoomUnit
  {
    public int SubType = -1;
    public int OwnerId = -1;
    public string OwnerName = "";
    public int RarityLevel = -1;
    public bool IsSaddle = false;
    public bool IsRiding = false;
    public bool CanBreed = false;
    public bool CanHarvest = false;
    public bool CanRevive = false;
    public bool HasBreedingPermission = false;
    public int Level = -1;
    public string Posture = "";

    public RoomPet()
    {
    }

    public new void Parse(IncomingPacket packet)
    {
      SubType = packet.GetInt();
      OwnerId = packet.GetInt();
      OwnerName = packet.GetString();
      RarityLevel = packet.GetInt();
      IsSaddle = packet.GetBool();
      IsRiding = packet.GetBool();
      CanBreed = packet.GetBool();
      CanHarvest = packet.GetBool();
      CanRevive = packet.GetBool();
      HasBreedingPermission = packet.GetBool();
      Level = packet.GetInt();
      Posture = packet.GetString();
    }

  }
}
