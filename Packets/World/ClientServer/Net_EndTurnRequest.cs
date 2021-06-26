using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.NetworkShared.Packets.World.ClientServer
{
    public struct Net_EndTurnRequest : INetPacket
    {
        public PacketType Type => PacketType.EndTurnRequest;

        public void Deserialize(NetDataReader reader)
        {
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
        }
    }
}
