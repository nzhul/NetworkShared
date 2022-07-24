using LiteNetLib.Utils;
using NetworkingShared;
using NetworkShared.Models;

namespace GameServer.NetworkShared.Packets.Battle.ClientServer
{
    public struct Net_BattleAttackRequest : INetPacket
    {
        public PacketType Type => PacketType.BattleAttackRequest;

        public int AttackerUnitId { get; set; }

        public int TargetUnitId { get; set; }

        public Coord AttackPosition { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            AttackerUnitId = reader.GetInt();
            TargetUnitId = reader.GetInt();
            AttackPosition = reader.Get<Coord>();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(AttackerUnitId);
            writer.Put(TargetUnitId);
            writer.Put(AttackPosition);
        }
    }
}
