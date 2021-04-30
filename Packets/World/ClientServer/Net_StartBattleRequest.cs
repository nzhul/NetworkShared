using LiteNetLib.Utils;
using NetworkShared.Enums;

namespace NetworkingShared.Packets.World.ClientServer
{
    public struct Net_StartBattleRequest : INetPacket
    {
        public PacketType Type => PacketType.StartBattleRequest;

        public int AttackerArmyId { get; set; }

        public int DefenderArmyId { get; set; }

        public PlayerType AttackerType { get; set; }

        public PlayerType DefenderType { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            AttackerArmyId = reader.GetInt();
            DefenderArmyId = reader.GetInt();
            AttackerType = (PlayerType)reader.GetByte();
            DefenderType = (PlayerType)reader.GetByte();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(AttackerArmyId);
            writer.Put(DefenderArmyId);
            writer.Put((byte)AttackerType);
            writer.Put((byte)DefenderType);
        }

        public bool IsValid()
        {
            bool result = true;

            if (this.AttackerArmyId == 0)
            {
                return false;
            }

            if (this.DefenderArmyId == 0)
            {
                return false;
            }

            return result;
        }
    }
}
