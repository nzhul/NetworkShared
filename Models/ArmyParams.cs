using LiteNetLib.Utils;

namespace NetworkShared.Models
{
    public class ArmyParams : INetSerializable
    {
        public ArmyParams()
        {
        }

        public ArmyParams(int id, int order, int ownerSelectedUnitId, int enemySelectedUnitId)
        {
            Id = id;
            Order = order;
            //SelectedUnitId = selectedUnitId;
            OwnerSelectedUnitId = ownerSelectedUnitId;
            EnemySelectedUnitId = enemySelectedUnitId;
        }

        public int Id { get; set; }

        public int Order { get; set; }

        //public int SelectedUnitId { get; set; }

        public int OwnerSelectedUnitId { get; set; }

        public int EnemySelectedUnitId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Order = reader.GetInt();
            //SelectedUnitId = reader.GetInt();
            OwnerSelectedUnitId = reader.GetInt();
            EnemySelectedUnitId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Order);
            //writer.Put(SelectedUnitId);
            writer.Put(OwnerSelectedUnitId);
            writer.Put(EnemySelectedUnitId);
        }
    }
}
