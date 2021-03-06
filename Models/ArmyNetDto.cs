using LiteNetLib.Utils;

namespace NetworkShared.Models
{
    public class ArmyNetDto : INetSerializable
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GameId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public NPCDataNetDto NPCData { get; set; }

        public bool IsNPC { get; set; }

        public Team Team { get; set; }

        public int OwnerSelectedUnitId { get; set; }

        public int EnemySelectedUnitId { get; set; }

        public UnitNetDto[] Units { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            UserId = reader.GetInt();
            GameId = reader.GetInt();
            X = reader.GetInt();
            Y = reader.GetInt();

            var npcDataExists = reader.GetBool();
            if (npcDataExists) NPCData = reader.Get<NPCDataNetDto>();

            IsNPC = reader.GetBool();
            Team = (Team)reader.GetByte();
            OwnerSelectedUnitId = reader.GetInt();
            EnemySelectedUnitId = reader.GetInt();

            var unitsLength = reader.GetUShort();
            Units = new UnitNetDto[unitsLength];
            for (int i = 0; i < unitsLength; i++)
            {
                Units[i] = reader.Get<UnitNetDto>();
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(UserId);
            writer.Put(GameId);
            writer.Put(X);
            writer.Put(Y);

            if (NPCData != null)
            {
                writer.Put(true);
                writer.Put(NPCData);
            }
            else
            {
                writer.Put(false);
            }

            writer.Put(IsNPC);
            writer.Put((byte)Team);
            writer.Put(OwnerSelectedUnitId);
            writer.Put(EnemySelectedUnitId);
            writer.Put((ushort)Units.Length);
            for (int i = 0; i < Units.Length; i++)
            {
                writer.Put(Units[i]);
            }
        }
    }
}
