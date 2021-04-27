namespace NetworkingShared
{
    public interface IPacketHandler
    {
        void Handle(INetPacket packet, int connectionId);
    }
}
