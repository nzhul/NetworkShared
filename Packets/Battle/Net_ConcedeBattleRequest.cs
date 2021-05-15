using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.NetworkShared.Packets.Battle
{
    public struct Net_ConcedeBattleRequest : INetPacket
    {
        public PacketType Type => PacketType.ConcedeBattleRequest;

        public void Deserialize(NetDataReader reader)
        {
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
        }
    }
}
