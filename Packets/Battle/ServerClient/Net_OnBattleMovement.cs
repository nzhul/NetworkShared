using LiteNetLib.Utils;
using NetworkingShared;
using NetworkShared.Models;

namespace Assets.Scripts.Network.NetworkShared.Packets.Battle.ServerClient
{
    public struct Net_OnBattleMovement : INetPacket
    {
        public PacketType Type => PacketType.OnBattleMovement;

        public int UnitId { get; set; }

        public Coord Destination { get; set; }

        public bool ShouldAttackTarget { get; set; }

        public int TargetUnitId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            UnitId = reader.GetInt();
            Destination = reader.Get<Coord>();
            ShouldAttackTarget = reader.GetBool();
            TargetUnitId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(UnitId);
            writer.Put(Destination);
            writer.Put(ShouldAttackTarget);
            writer.Put(TargetUnitId);
        }
    }
}
