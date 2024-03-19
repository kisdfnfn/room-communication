using Habbo.Core.Math;

namespace Habbo.Core.Room
{
  public class Room
  {
    public List<RoomUnit> Units = new List<RoomUnit>();
    List<RoomFurni> Furnis = new List<RoomFurni>();
    int Score = -1;
    bool CanVote = false;
    bool Loaded = false;

    public Room()
    {
    }

    public RoomFurni? GetFurniByPosition(int x, int y)
    {
      return Furnis.Find(furni => furni.Position.Equal(x, y));
    }

    public RoomFurni? GetFurniByPosition(int x, int y, double z)
    {
      return Furnis.Find(furni => furni.Position.Equal(x, y, z));
    }

    public RoomFurni? GetFurniByPosition(Vector position)
    {
      return Furnis.Find(furni => furni.Position.Equal(position));
    }

    public RoomUnit? GetUnitByUsername(string username)
    {
      return Units.Find(unit => unit.Username == username);
    }

    public RoomUnit? GetUnitByRoomIndex(int roomIndex)
    {
      return Units.Find(unit => unit.RoomIndex == roomIndex);
    }

    public void Clear()
    {
      Units.Clear();
      Furnis.Clear();
    }
  }
}
