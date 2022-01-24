using LiteNetLib.Utils;
using NetworkingShared;
using NetworkShared.Models;

namespace Assets.Scripts.Network.NetworkShared.Packets.Battle.ClientServer
{
    public struct Net_BattleMovementRequest : INetPacket
    {
        public PacketType Type => PacketType.BattleMovementRequest;

        public int UnitId { get; set; }

        public Coord Destination { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            UnitId = reader.GetInt();
            Destination = reader.Get<Coord>();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(UnitId);
            writer.Put(Destination);
        }
    }
}
