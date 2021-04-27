using System;

namespace NetworkingShared.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class HandlerRegisterAttribute : Attribute
    {
        public HandlerRegisterAttribute(PacketType type)
        {
            PacketType = type;
        }

        public PacketType PacketType { get; }
    }
}
