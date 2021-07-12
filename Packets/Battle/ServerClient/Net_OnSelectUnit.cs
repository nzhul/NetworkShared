using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.Battle.ServerClient
{
    public struct Net_OnSelectUnit : INetPacket
    {
        public PacketType Type => PacketType.OnSelectUnit;

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
