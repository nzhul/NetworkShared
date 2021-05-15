using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.NetworkShared.Packets.Battle
{
    public struct Net_OnEndBattleEvent : INetPacket
    {
        public PacketType Type => PacketType.OnEndBattle;

        public int WinnerId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            WinnerId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(WinnerId);
        }
    }
}
