﻿using System;

namespace NetworkingShared.Packets.World.ServerClient
{
    [Serializable]
    public class Net_OnStartGame : NetMessage
    {
        public Net_OnStartGame()
        {
            OperationCode = NetOperationCode.OnStartGame;
        }

        public int GameId { get; set; }
    }
}
