using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.World.ServerClient
{
    public struct Net_OnReconnectBattleFail : INetPacket
    {
        public PacketType Type => PacketType.OnReconnectBattleFail;

        public void Deserialize(NetDataReader reader)
        {
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
        }
    }
}
