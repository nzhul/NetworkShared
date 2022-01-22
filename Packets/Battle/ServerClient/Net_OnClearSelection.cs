using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.Battle.ServerClient
{
    public struct Net_OnClearSelection : INetPacket
    {
        public PacketType Type => PacketType.OnClearSelection;

        public int ActorUserId { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            ActorUserId = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(ActorUserId);
        }
    }
}
