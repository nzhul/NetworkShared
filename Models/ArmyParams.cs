using LiteNetLib.Utils;

namespace GameServer.NetworkShared.Models
{
    public class ArmyParams : INetSerializable
    {
        public ArmyParams()
        {
        }

        public ArmyParams(int id, int order)
        {
            Id = id;
            Order = order;
        }

        public int Id { get; set; }

        public int Order { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Order = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Order);
        }
    }
}
