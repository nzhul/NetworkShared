using System;

namespace GameServer.NetworkShared
{
    public static class Constants
    {
        public readonly static TimeSpan BATTLE_TURN_DURATION = new TimeSpan(0, 0, 20);
        public readonly static TimeSpan IDLE_TIMEOUT = new TimeSpan(0, 5, 50); // Use this for testing. Real one is bellow!
        //private const int IDLE_TIMEOUT = (TURN_DURATION * 2) + (TURN_DURATION / 2); // seconds -> 20 * 2 + 20 / 2 = 40 + 10 = 50
        public readonly static TimeSpan DAY_DURATION = new TimeSpan(0, 0, 20);
    }
}
