using System;
using LiteNetLib.Utils;

namespace NetworkingShared.Packets.World.ClientServer
{
    public struct Net_ReconnectBattleRequest : INetPacket
    {
        public PacketType Type => PacketType.ReconnectBattleRequest;

        public int GameId { get; set; } // TODO: later on the game id should be resolved by the server.

        public Guid BattleId { get; set; } // TODO: later on the battle id should be resolved by the server.

        public void Deserialize(NetDataReader reader)
        {
            GameId = reader.GetInt();
            BattleId = Guid.Parse(reader.GetString());
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(GameId);
            writer.Put(BattleId.ToString());
        }
    }
}
