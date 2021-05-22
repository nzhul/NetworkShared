using LiteNetLib.Utils;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnStartGame : INetPacket
    {
        public int GameId { get; set; }

        public string GameString { get; set; }

        public PacketType Type => PacketType.OnStartGame;

        public void Deserialize(NetDataReader reader)
        {
            GameId = reader.GetInt();
            GameString = reader.GetString();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(GameId);
            writer.Put(GameString);
        }
    }
}