using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.Battle.ClientServer
{
    public struct Net_BattleAttackRequest : INetPacket
    {
        public PacketType Type => PacketType.BattleAttackRequest;

        public int AttackerUnitId { get; set; }

        public int TargetUnitId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            AttackerUnitId = reader.GetInt();
            TargetUnitId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(AttackerUnitId);
            writer.Put(TargetUnitId);
        }
    }
}
