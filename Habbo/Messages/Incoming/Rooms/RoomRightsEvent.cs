namespace Habbo.Messages.Incoming.Rooms
{
    public class RoomRightsEvent : IncomingPacket
    {
        public int ControllerLevel;

        public RoomRightsEvent(byte[] data) : base(data)
        {
            ControllerLevel = GetInt();
            // connection.client.room.units = [];
            // client.room.loaded = true;

            // connection.send(new RoomModelComposer());
        }

    }
}
