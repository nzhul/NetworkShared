using System;
using LiteNetLib;

namespace NetworkingShared
{
    public static class NetworkUtils
    {
        public static INetPacket ResolvePacket(PacketType packetType, NetPacketReader reader)
        {

            var type = PacketRegistry.PacketTypes[packetType];
            var packet = (INetPacket)Activator.CreateInstance(type);
            packet.Deserialize(reader);
            return packet;
        }
    }
}
