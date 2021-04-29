using LiteNetLib.Utils;
using NetworkShared.Models;

namespace NetworkingShared.Packets.World.ClientServer
{
    public struct Net_MapMovementRequest : INetPacket
    {
        public PacketType Type => PacketType.MapMovementRequest;

        public int ArmyId { get; set; }

        public Coord Destination { get; set; }



        public void Deserialize(NetDataReader reader)
        {
            ArmyId = reader.GetInt();
            Destination = reader.Get<Coord>();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(ArmyId);
            writer.Put(Destination);
        }
    }
}