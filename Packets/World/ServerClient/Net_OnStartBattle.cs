using System;
using GameServer.NetworkShared.Models;
using LiteNetLib.Utils;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnStartBattle : INetPacket
    {
        public PacketType Type => PacketType.OnStartBattle;

        public Guid BattleId { get; set; }

        public int CurrentArmyId { get; set; }

        public int CurrentUnitId { get; set; }

        public ArmyParams[] Armies { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            BattleId = Guid.Parse(reader.GetString());
            CurrentArmyId = reader.GetInt();
            CurrentUnitId = reader.GetInt();

            var armiesLength = reader.GetUShort();
            Armies = new ArmyParams[armiesLength];
            for (int i = 0; i < armiesLength; i++)
            {
                Armies[i] = reader.Get<ArmyParams>();
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(BattleId.ToString());
            writer.Put(CurrentArmyId);
            writer.Put(CurrentUnitId);
            writer.Put((ushort)Armies.Length);
            for (int i = 0; i < Armies.Length; i++)
            {
                writer.Put(Armies[i]);
            }
        }
    }
}
