using LiteNetLib.Utils;

namespace NetworkShared.Models
{
    public class AvatarNetDto : INetSerializable
    {
        public int UserId { get; set; }

        public int Wood { get; set; }

        public int Ore { get; set; }

        public int Gold { get; set; }

        public int Gems { get; set; }

        public Team Team { get; set; }

        public string VisitedString { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            UserId = reader.GetInt();
            Wood = reader.GetInt();
            Ore = reader.GetInt();
            Gold = reader.GetInt();
            Gems = reader.GetInt();
            Team = (Team)reader.GetByte();
            VisitedString = reader.GetString();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(UserId);
            writer.Put(Wood);
            writer.Put(Ore);
            writer.Put(Gold);
            writer.Put(Gems);
            writer.Put((byte)Team);
            writer.Put(VisitedString);
        }
    }
}
