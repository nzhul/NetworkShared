using LiteNetLib.Utils;
using NetworkingShared.Enums;

namespace NetworkingShared.Packets.World.ClientServer
{
    public struct Net_FindOpponentRequest : INetPacket
    {
        public PacketType Type => PacketType.FindOpponentRequest;

        public CreatureType Class { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Class = (CreatureType)reader.GetByte();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put((byte)Class);
        }
    }
}
