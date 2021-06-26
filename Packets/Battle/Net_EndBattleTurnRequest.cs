﻿using System;
using LiteNetLib.Utils;

namespace NetworkingShared.Packets.Battle
{
    public struct Net_EndBattleTurnRequest : INetPacket
    {
        public PacketType Type => PacketType.EndBattleTurnRequest;

        public Guid BattleId { get; set; }

        public int RequesterArmyId { get; set; }

        public int RequesterUnitId { get; set; }

        public bool IsDefend { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            BattleId = Guid.Parse(reader.GetString());
            RequesterArmyId = reader.GetInt();
            RequesterUnitId = reader.GetInt();
            IsDefend = reader.GetBool();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(BattleId.ToString());
            writer.Put(RequesterArmyId);
            writer.Put(RequesterUnitId);
            writer.Put(IsDefend);
        }
    }
}
