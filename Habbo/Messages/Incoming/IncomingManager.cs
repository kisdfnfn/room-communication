using Habbo.Messages.Incoming.Handshake;
using Habbo.Messages.Incoming.Users;
using Habbo.Messages.Incoming.Rooms;
using Habbo.Messages.Incoming.Rooms.Users;

namespace Habbo.Messages.Incoming
{
  public class IncomingManager
  {
    public Dictionary<short, Type> events;

    public IncomingManager()
    {
      events = new Dictionary<short, Type>();

      RegisterHanshake();
      RegisterTracking();
      RegisterUsers();
      RegisterGameCenter();
      RegisterFriends();
      RegisterNavigator();
      RegisterInventory();
      RegisterCatalog();
      RegisterRooms();
    }

    void Register(short header, Type ev)
    {
      events[header] = ev;
    }

    void RegisterHanshake()
    {
      Register(IncomingHeaders.HandshakeSuccess, typeof(HandshakeSuccessEvent));
      Register(IncomingHeaders.Ping, typeof(PingEvent));
      // Register(IncomingHeaders.MachineID, typeof(MachineIDEvent));
      // Register(IncomingHeaders.SecureLogin, typeof(SecureLoginEvent));
      // Register(IncomingHeaders.RequestUserData, typeof(RequestUserDataEvent));
      // Register(IncomingHeaders.Ping, typeof(PingEvent));
    }

    void RegisterTracking()
    {
      // Register(IncomingHeaders.PerformanceLog, typeof(PerformanceLogEvent));
    }

    void RegisterUsers()
    {
      Register(IncomingHeaders.UserData, typeof(UserDataEvent));
      // Register(IncomingHeaders.RequestUserCredits, typeof(RequestUserCreditsEvent));
      // Register(IncomingHeaders.RequestUserClub, typeof(RequestUserClubEvent));
      // Register(IncomingHeaders.RequestSoundSettings, typeof(RequestSoundSettingsEvent));
    }

    void RegisterGameCenter()
    {
      // Register(IncomingHeaders.RequestGames, typeof(RequestGamesEvent));
      // Register(IncomingHeaders.GetGameAchievements, typeof(GetGameAchievementsEvent));
    }

    void RegisterFriends()
    {
      // Register(IncomingHeaders.RequestFriends, typeof(RequestFriendsEvent));
      // Register(IncomingHeaders.RequestInitFriends, typeof(RequestInitFriendsEvent));
    }

    void RegisterNavigator()
    {
      // Register(IncomingHeaders.RequestInitNavigator, typeof(RequestInitNavigatorEvent));
      // Register(IncomingHeaders.RequestPromotedRooms, typeof(RequestPromotedRoomsEvent));
    }

    void RegisterInventory()
    {
      // Register(IncomingHeaders.GetBadgePointLimits, typeof(GetBadgePointLimitsEvent));
    }

    void RegisterCatalog()
    {
      // Register(IncomingHeaders.RequestTargetOffer, typeof(RequestTargetOfferEvent));
    }

    void RegisterRooms()
    {
      Register(IncomingHeaders.RoomOpen, typeof(RoomOpenEvent));
      Register(IncomingHeaders.RoomModel, typeof(RoomModelEvent));
      Register(IncomingHeaders.RoomPaint, typeof(RoomPaintEvent));
      Register(IncomingHeaders.RoomScore, typeof(RoomScoreEvent));
      Register(IncomingHeaders.RoomRelativeMap, typeof(RoomRelativeMapEvent));
      Register(IncomingHeaders.RoomRights, typeof(RoomRightsEvent));
      // > Users
      Register(IncomingHeaders.RoomUserTalk, typeof(RoomUserTalkEvent));
      Register(IncomingHeaders.RoomUsers, typeof(RoomUsersEvent));
    }

    public IncomingPacket? GetEvent(short header, byte[] data)
    {
      if (events.ContainsKey(header))
      {
        return (IncomingPacket?)Activator.CreateInstance(events[header], data);
      }
      return null;
    }

  }
}