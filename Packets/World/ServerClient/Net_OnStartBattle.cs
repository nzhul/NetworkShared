using LiteNetLib.Utils;
using NetworkShared.Models;
using System;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnStartBattle : INetPacket
    {
        public PacketType Type => PacketType.OnStartBattle;

        public Guid BattleId { get; set; }

        public int CurrentArmyId { get; set; }

        public ArmyParams[] Armies { get; set; }

        public int GameId { get; set; }

        public string GameString { get; set; }

        public GameNetDto GameState { get; set; }

        public DateTime CurrentTurnStartTime { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            BattleId = Guid.Parse(reader.GetString());
            CurrentArmyId = reader.GetInt();

            var armiesLength = reader.GetUShort();
            Armies = new ArmyParams[armiesLength];
            for (int i = 0; i < armiesLength; i++)
            {
                Armies[i] = reader.Get<ArmyParams>();
            }

            GameId = reader.GetInt();
            GameString = reader.GetString();
            GameState = reader.Get<GameNetDto>();
            CurrentTurnStartTime = DateTime.Parse(reader.GetString());
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(BattleId.ToString());
            writer.Put(CurrentArmyId);
            writer.Put((ushort)Armies.Length);
            for (int i = 0; i < Armies.Length; i++)
            {
                writer.Put(Armies[i]);
            }
            writer.Put(GameId);
            writer.Put(GameString);
            writer.Put(GameState);
            writer.Put(CurrentTurnStartTime.ToString());
        }
    }
}
