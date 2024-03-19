using Habbo.Core.Room;

namespace Habbo.Messages.Incoming.Rooms.Users
{
  class RoomUsersEvent : IncomingPacket
  {
    public List<RoomUnit> units = new List<RoomUnit>();

    public RoomUsersEvent(byte[] data) : base(data)
    {
      int count = GetInt();
      Console.WriteLine($"{count} count");
      for (var i = 0; i < count; i++)
      {
        int id = GetInt();
        Console.WriteLine($"{PeekShort()} short");
        string username = GetString();
        string motto = GetString();
        string figure = GetString();
        int roomIndex = GetInt();
        int roomX = GetInt();
        int roomY = GetInt();
        string roomZ = GetString();
        int bodyRotation = GetInt();
        RoomUnitType type = (RoomUnitType)GetInt();

        // Console.WriteLine($"Username: {username}\nMotto: {motto}\nFigure: {figure}\nRoomIndex: {roomIndex}");
        // Console.WriteLine($"X: {roomX}\nY: {roomY}\nZ: {roomZ}\nBodyRotation: {bodyRotation}\nType: {type}");

        RoomUnit? unit = null;

        switch (type)
        {
          case RoomUnitType.User:
            {
              unit = new RoomUser();
              break;
            }
          case RoomUnitType.Pet:
            {
              // unit = new RoomPet();
              break;
            }
          case RoomUnitType.Bot:
            {
              // unit = new RoomBot();
              break;
            }
          case RoomUnitType.RentableBot:
            {
              // unit = new RoomRentableBot();
              break;
            }
        }

        if (unit == null)
        {
          // throw new Exception("Error");
          break;
        }

        unit.Id = id;
        unit.Username = username;
        unit.Motto = motto;
        unit.Figure = figure;
        unit.RoomIndex = roomIndex;
        unit.Position.Set(roomX, roomY, double.Parse(roomZ));
        unit.BodyRotation = bodyRotation;

        unit.Parse(this);

        units.Add(unit);
      }
    }

  }
}
