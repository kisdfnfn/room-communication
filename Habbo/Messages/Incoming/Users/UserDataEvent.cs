namespace Habbo.Messages.Incoming.Users
{
  class UserDataEvent : IncomingPacket
  {
    public int Id;
    public string Username;
    public string Figure;
    public string Gender;
    public string Motto;
    public int RespectPointsReceived;
    public int RespectPointsToGive;
    public int PetRespectPointsToGive;

    public UserDataEvent(byte[] data) : base(data)
    {
      Id = GetInt();
      Username = GetString();
      Figure = GetString();
      Gender = GetString();
      Motto = GetString();
      GetString(); // realName (Username)
      GetBool(); // ??
      RespectPointsReceived = GetInt();
      RespectPointsToGive = GetInt();
      PetRespectPointsToGive = GetInt();
      GetBool(); // ??
      GetString(); // Data de criação
      GetBool(); // can change name?
      GetBool(); // ??
    }

  }
}
