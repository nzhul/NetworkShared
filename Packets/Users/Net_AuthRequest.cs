using LiteNetLib.Utils;
using NetworkingShared;

namespace Assets.Scripts.Network.Shared.NetMessages.Users
{
    // TODO: AuthRequest should not pass all this information.
    // Server should do another request to the server to fetch user details like:
    // MMR, GameId, BattleId etc.
    public struct Net_AuthRequest : INetPacket
    {
        public PacketType Type => PacketType.AuthRequest;

        public string Username { get; set; }

        public string Password { get; set; }

        public void Deserialize(NetDataReader reader)
        {
            Username = reader.GetString();
            Password = reader.GetString();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
            writer.Put(Username);
            writer.Put(Password);
        }
    }
}