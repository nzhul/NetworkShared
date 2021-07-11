using LiteNetLib.Utils;

namespace GameServer.NetworkShared.Models
{
    public class ArmyParams : INetSerializable
    {
        public ArmyParams()
        {
        }

        public ArmyParams(int id, int order, int selectedUnitId)
        {
            Id = id;
            Order = order;
            SelectedUnitId = selectedUnitId;
        }

        public int Id { get; set; }

        public int Order { get; set; }

        public int SelectedUnitId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Order = reader.GetInt();
            SelectedUnitId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Order);
            writer.Put(SelectedUnitId);
        }
    }
}
