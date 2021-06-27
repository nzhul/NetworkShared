using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.World.ServerClient
{
    public struct Net_OnNewDay : INetPacket
    {
        public PacketType Type => PacketType.OnNewDay;

        public int CurrentDay { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            CurrentDay = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(CurrentDay);
        }
    }
}
