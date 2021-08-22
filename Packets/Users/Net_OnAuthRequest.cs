using System;
using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.Shared.NetMessages.Users
{
    public struct Net_OnAuthRequest : INetPacket
    {
        public PacketType Type => PacketType.OnAuthRequest;

        public int ConnectionId { get; set; }

        public byte Success { get; set; }

        public string ErrorMessage { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public int MMR { get; set; }

        public string Token { get; set; }

        public int? GameId { get; set; }

        public Guid? BattleId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            ConnectionId = reader.GetInt();
            Success = reader.GetByte();
            ErrorMessage = reader.GetString();
            UserId = reader.GetInt();
            Username = reader.GetString();
            MMR = reader.GetInt();
            Token = reader.GetString();

            if (reader.TryGetInt(out int gameId))
            {
                GameId = gameId;
            }
            if (reader.TryGetString(out string battleIdString))
            {
                BattleId = Guid.Parse(battleIdString);
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(ConnectionId);
            writer.Put(Success);
            writer.Put(ErrorMessage);
            writer.Put(UserId);
            writer.Put(Username);
            writer.Put(MMR);
            writer.Put(Token);

            if (GameId.HasValue)
            {
                writer.Put(GameId.Value);
            }
            if (BattleId.HasValue)
            {
                writer.Put(BattleId.Value.ToString());
            }
        }
    }
}
