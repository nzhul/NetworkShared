using LiteNetLib.Utils;
using NetworkingShared.Enums;

namespace NetworkShared.Models
{
    public class UnitNetDto : INetSerializable
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int StartX { get; set; }

        public int StartY { get; set; }

        public int Level { get; set; }

        public int UserId { get; set; }

        public int GameId { get; set; }

        public int ArmyId { get; set; }

        public CreatureType Type { get; set; }

        public int Quantity { get; set; }

        public int MovementPoints { get; set; }

        public int Hitpoints { get; set; }

        public int Mana { get; set; }

        public int ActionPoints { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            X = reader.GetInt();
            Y = reader.GetInt();
            StartX = reader.GetInt();
            StartY = reader.GetInt();
            Level = reader.GetInt();
            UserId = reader.GetInt();
            GameId = reader.GetInt();
            ArmyId = reader.GetInt();
            Type = (CreatureType)reader.GetByte();
            Quantity = reader.GetInt();
            MovementPoints = reader.GetInt();
            Hitpoints = reader.GetInt();
            Mana = reader.GetInt();
            ActionPoints = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(X);
            writer.Put(Y);
            writer.Put(StartX);
            writer.Put(StartY);
            writer.Put(Level);
            writer.Put(UserId);
            writer.Put(GameId);
            writer.Put(ArmyId);
            writer.Put((byte)Type);
            writer.Put(Quantity);
            writer.Put(MovementPoints);
            writer.Put(Hitpoints);
            writer.Put(Mana);
            writer.Put(ActionPoints);
        }
    }
}
