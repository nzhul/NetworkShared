using LiteNetLib.Utils;

namespace NetworkShared.Models
{
    public class Coord : INetSerializable
    {

        public Coord()
        {
        }

        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            X = reader.GetInt();
            Y = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(X);
            writer.Put(Y);
        }
    }
}
