using System;
using NetworkingShared.Enums;

namespace NetworkingShared.Packets.World.ClientServer
{
    [Serializable]
    public class Net_FindOpponentRequest : NetMessage
    {
        public Net_FindOpponentRequest()
        {
            OperationCode = NetOperationCode.FindOpponentRequest;
        }

        public CreatureType Class { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}
