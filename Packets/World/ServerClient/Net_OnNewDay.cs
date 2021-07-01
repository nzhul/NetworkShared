using LiteNetLib.Utils;
using NetworkingShared;

namespace GameServer.NetworkShared.Packets.World.ServerClient
{
    public struct Net_OnNewDay : INetPacket
    {
        public PacketType Type => PacketType.OnNewDay;

        public int Day { get; set; }

        public int Week { get; set; }

        public int Month { get; set; }

        public int TotalDays { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Day = reader.GetInt();
            Week = reader.GetInt();
            Month = reader.GetInt();
            TotalDays = reader.GetInt();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(Day);
            writer.Put(Week);
            writer.Put(Month);
            writer.Put(TotalDays);
        }
    }
}
