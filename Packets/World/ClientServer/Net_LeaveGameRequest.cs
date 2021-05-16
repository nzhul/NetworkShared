using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.NetworkShared.Packets.World.ClientServer
{
    public struct Net_LeaveGameRequest : INetPacket
    {
        public PacketType Type => PacketType.LeaveGameRequest;

        public void Deserialize(NetDataReader reader)
        {
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
        }
    }
}
