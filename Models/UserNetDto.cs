using LiteNetLib.Utils;

namespace NetworkShared.Models
{
    public class UserNetDto : INetSerializable
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Username = reader.GetString();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Username);
        }
    }
}
