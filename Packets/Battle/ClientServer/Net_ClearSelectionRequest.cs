using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.NetworkShared.Packets.Battle
{
    public struct Net_ClearSelectionRequest : INetPacket
    {
        public PacketType Type => PacketType.ClearSelectionRequest;

        public void Deserialize(NetDataReader reader)
        {
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
        }
    }
}
