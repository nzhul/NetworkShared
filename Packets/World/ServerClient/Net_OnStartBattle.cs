using System;
using LiteNetLib.Utils;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnStartBattle : INetPacket
    {
        public PacketType Type => PacketType.OnStartBattle;

        public Guid BattleId { get; set; }

        public int CurrentArmyId { get; set; }

        public int CurrentUnitId { get; set; }

        public int[] Armies { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            BattleId = Guid.Parse(reader.GetString());
            CurrentUnitId = reader.GetInt();
            CurrentArmyId = reader.GetInt();
            Armies = reader.GetIntArray();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(BattleId.ToString());
            writer.Put(CurrentArmyId);
            writer.Put(CurrentUnitId);
            writer.PutArray(Armies);
        }
    }
}
