using LiteNetLib.Utils;
using NetworkingShared;
using NetworkShared.Models;

namespace GameServer.NetworkShared.Packets.Battle.ServerClient
{
    public struct Net_OnBattleAttack : INetPacket
    {
        public PacketType Type => PacketType.OnBattleAttack;

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
