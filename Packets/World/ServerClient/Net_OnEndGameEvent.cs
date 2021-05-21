using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.World.ServerClient
{
    public struct Net_OnEndGameEvent : INetPacket
    {
        public PacketType Type => PacketType.OnEndGame;

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
