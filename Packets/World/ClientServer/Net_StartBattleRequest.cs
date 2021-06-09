using LiteNetLib.Utils;

namespace NetworkingShared.Packets.World.ClientServer
{
    public struct Net_StartBattleRequest : INetPacket
    {
        public PacketType Type => PacketType.StartBattleRequest;

        public int AttackerArmyId { get; set; }

        public int DefenderArmyId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            AttackerArmyId = reader.GetInt();
            DefenderArmyId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(AttackerArmyId);
            writer.Put(DefenderArmyId);
        }
    }
}
