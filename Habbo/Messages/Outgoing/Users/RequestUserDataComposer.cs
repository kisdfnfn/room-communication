using System;

namespace Habbo.Messages.Outgoing.Users
{
  class RequestUserDataComposer : OutgoingPacket
  {

    public RequestUserDataComposer() : base(OutgoingHeaders.RequestUserData)
    {
    }

  }
}
