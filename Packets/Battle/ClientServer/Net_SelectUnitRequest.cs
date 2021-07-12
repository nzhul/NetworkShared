using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.NetworkShared.Packets.Battle
{
    public struct Net_SelectUnitRequest : INetPacket
    {
        public PacketType Type => PacketType.SelectUnitRequest;

        public int SelectedUnitId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            SelectedUnitId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(SelectedUnitId);
        }
    }
}
