using LiteNetLib.Utils;
using NetworkShared.Models;

namespace NetworkingShared.Packets.World.ServerClient
{
    public struct Net_OnMapMovement : INetPacket
    {
        public PacketType Type => PacketType.OnMapMovement;

        public string Error { get; set; }

        public byte Success { get; set; }

        public int ArmyId { get; set; }

        public Coord Destination { get; set; }



        public void Deserialize(NetDataReader reader)
        {
            Error = reader.GetString();
            Success = reader.GetByte();
            ArmyId = reader.GetInt();
            Destination = reader.Get<Coord>();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(Error);
            writer.Put(Success);
            writer.Put(ArmyId);
            writer.Put(Destination);

        }
    }
}