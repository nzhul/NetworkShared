using System;

namespace NetworkingShared.Packets.World.ClientServer
{
    [Serializable]
    public class Net_CancelFindOpponentRequest : NetMessage
    {
        public Net_CancelFindOpponentRequest()
        {
            OperationCode = NetOperationCode.CancelFindOpponentRequest;
        }
    }
}
