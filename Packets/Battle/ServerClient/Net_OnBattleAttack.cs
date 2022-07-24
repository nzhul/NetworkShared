using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.Battle.ServerClient
{
    public struct Net_OnBattleAttack : INetPacket
    {
        public PacketType Type => PacketType.OnBattleAttack;

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
