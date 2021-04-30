using System;
using LiteNetLib.Utils;
using NetworkShared.Enums;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnStartBattle : INetPacket
    {
        public PacketType Type => PacketType.OnStartBattle;

        public Guid BattleId { get; set; }

        public int AttackerArmyId { get; set; }

        public int DefenderArmyId { get; set; }

        public int SelectedUnitId { get; set; }

        public PlayerType AttackerType { get; set; }

        public PlayerType DefenderType { get; set; }

        public BattleScenario BattleScenario { get; set; }

        public Turn Turn { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            BattleId = Guid.Parse(reader.GetString());
            AttackerArmyId = reader.GetInt();
            DefenderArmyId = reader.GetInt();
            SelectedUnitId = reader.GetInt();
            AttackerType = (PlayerType)reader.GetByte();
            DefenderType = (PlayerType)reader.GetByte();
            BattleScenario = (BattleScenario)reader.GetByte();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(AttackerArmyId);
            writer.Put(DefenderArmyId);
            writer.Put(SelectedUnitId);
            writer.Put((byte)AttackerType);
            writer.Put((byte)DefenderType);
            writer.Put((byte)BattleScenario);
        }
    }
}
