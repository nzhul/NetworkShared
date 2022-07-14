using LiteNetLib.Utils;
using NetworkingShared.Enums;
using System;

namespace NetworkShared.Models
{
    public class NPCDataNetDto : INetSerializable
    {
        public CreatureType MapRepresentation { get; set; }

        public Disposition Disposition { get; set; }

        public TreasureType RewardType { get; set; }

        public int RewardQuantity { get; set; }

        //public object ItemReward { get; set; }

        public CreatureType TroopsRewardType { get; set; }

        public int TroopsRewardQuantity { get; set; }

        public string OccupiedTilesString { get; set; }

        public DateTime LastDefeat { get; set; }

        public bool IsLocked { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            MapRepresentation = (CreatureType)reader.GetByte();
            Disposition = (Disposition)reader.GetByte();
            RewardType = (TreasureType)reader.GetByte();
            RewardQuantity = reader.GetInt();
            TroopsRewardType = (CreatureType)reader.GetByte();
            TroopsRewardQuantity = reader.GetInt();
            OccupiedTilesString = reader.GetString(); // do i need this ?
            LastDefeat = DateTime.Parse(reader.GetString());
            IsLocked = reader.GetBool();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)MapRepresentation);
            writer.Put((byte)Disposition);
            writer.Put((byte)RewardType);
            writer.Put(RewardQuantity);
            writer.Put((byte)TroopsRewardType);
            writer.Put(TroopsRewardQuantity);
            writer.Put(OccupiedTilesString);
            writer.Put(LastDefeat.ToString("O"));
            writer.Put(IsLocked);
        }
    }
}
