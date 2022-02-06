using System;
using LiteNetLib.Utils;

namespace NetworkingShared.Packets.Battle
{

    public struct Net_SwitchTurnEvent : INetPacket
    {
        public PacketType Type => PacketType.OnSwitchTurn;

        public Guid BattleId { get; set; }

        public int CurrentArmyId { get; set; }

        public int ExhaustedUnitId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            BattleId = Guid.Parse(reader.GetString());
            CurrentArmyId = reader.GetInt();
            ExhaustedUnitId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(BattleId.ToString());
            writer.Put(CurrentArmyId);
            writer.Put(ExhaustedUnitId);
        }
    }
}
