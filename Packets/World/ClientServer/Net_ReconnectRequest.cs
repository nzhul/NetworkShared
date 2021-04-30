using LiteNetLib.Utils;

namespace NetworkingShared.Packets.World.ClientServer
{
    public struct Net_ReconnectRequest : INetPacket
    {
        public PacketType Type => PacketType.ReconnectRequest;

        public int GameId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            GameId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(GameId)
        }
    }
}
