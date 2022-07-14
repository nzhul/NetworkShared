using LiteNetLib.Utils;

namespace NetworkShared.Models
{
    public class DwellingNetDto : INetSerializable
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Team Team { get; set; }

        public DwellingType Type { get; set; }

        public int? UserId { get; set; }

        public int? GameId { get; set; }

        public int? GuardianId { get; set; }

        public string OccupiedTilesString { get; set; }

        public string VisitorsString { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            X = reader.GetInt();
            Y = reader.GetInt();
            Team = (Team)reader.GetByte();
            Type = (DwellingType)reader.GetByte();
            if (reader.TryGetInt(out int userId)) UserId = userId;
            if (reader.TryGetInt(out int gameId)) GameId = gameId;
            if (reader.TryGetInt(out int guardianId)) GuardianId = guardianId;
            OccupiedTilesString = reader.GetString();
            VisitorsString = reader.GetString();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(X);
            writer.Put(Y);
            writer.Put((byte)Type);
            writer.Put((byte)Team);
            if (UserId.HasValue) writer.Put(UserId.Value);
            if (GameId.HasValue) writer.Put(GameId.Value);
            if (GuardianId.HasValue) writer.Put(GuardianId.Value);
            writer.Put(OccupiedTilesString);
            writer.Put(VisitorsString);
        }
    }
}
