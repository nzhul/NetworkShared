using LiteNetLib.Utils;
using NetworkShared.Models;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnStartGame : INetPacket
    {
        public int GameId { get; set; }

        public GameNetDto GameState { get; set; }

        public PacketType Type => PacketType.OnStartGame;

        public void Deserialize(NetDataReader reader)
        {
            GameId = reader.GetInt();
            GameState = reader.Get<GameNetDto>();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(GameId);
            writer.Put(GameState);
        }
    }
}