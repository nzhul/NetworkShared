using LiteNetLib.Utils;

namespace NetworkingShared
{
    #region Common
    public enum PacketType : byte
    {
        None = 0,

        #region ClientServer

        AuthRequest = 1,
        LoadRegionsRequest = 2,

        /// <summary>
        /// World enter request will force the dedicated server to load all the information about the user avatar
        /// together with the required regions
        /// </summary>
        WorldEnterRequest = 3,

        /// <summary>
        /// Request entity movement
        /// Do validation and if success -> send OnMovement message that contains the updated coordinates.
        /// </summary>
        MapMovementRequest = 4,

        /// <summary>
        /// Sends request for teleport to the dedicated server.
        /// 1. DDServer validates the request and sends back OnTeleport message.
        /// 2. Client listens for OnTeleport messages and execute the teleport.
        ///     - Cases:
        ///         1. self teleport -> the requester is the one that is teleporting
        ///         2. other player -> a player teleports in or out of our map.
        /// </summary>
        TeleportRequest = 5,

        /// <summary>
        /// Sends request for starting a battle to the dedicated server.
        /// 1. DDServer checks if the monster pack is not locked and sends back OnStartBattle message.
        /// 2. Client listens for this message and starts the battle by loading separate "battle" scene.
        /// </summary>
        StartBattleRequest = 6,

        /// <summary>
        /// Each player should send this message after he is done loading the battle scene.
        /// Then we know that the battle can start.
        /// </summary>
        ConfirmLoadingBattleScene = 7,

        /// <summary>
        /// A player that currently have an active turn can send an EndBattleTurnRequest 
        /// to end his turn befire his time expires
        /// The player should not be able to send such request if current turn is not 
        /// his or there is X time left from his turn.
        /// </summary>
        EndBattleTurnRequest = 8,

        /// <summary>
        /// Sends request for joining the matchmaking queue and start searching for opponent.
        /// </summary>
        FindOpponentRequest = 9,

        /// <summary>
        /// Sends a request for leaving matchmaking pool.
        /// </summary>
        CancelFindOpponentRequest = 10,

        /// <summary>
        /// Sends a request for disconnecting from the server and going offline.
        /// </summary>
        LogoutRequest = 11,

        /// <summary>
        /// Sends a request for reconnecting to a game.
        /// NOTE: This will be used only while developing so we can load the game server side when we need it.
        /// </summary>
        ReconnectRequest = 12,

        /// <summary>
        /// Sends a request for reconnecting to a battle.
        /// This message is send when the player still have active game and wants to reconnect to it.
        /// </summary>
        ReconnectBattleRequest = 13,

        /// <summary>
        /// Sends a request for conceding the battle.
        /// This message is send when the player intentionaly decide that he want to loose the battle.
        /// </summary>
        ConcedeBattleRequest = 14,

        /// <summary>
        /// Sends a request for leaving a game.
        /// This message is send when the player intentionally decicde that he want to loose the game.
        /// </summary>
        LeaveGameRequest = 15,

        /// <summary>
        /// Sends a request for ending a regular world/map turn. Eg: Resting
        /// If all armies have consumed their movement points, the server will emit NewDayEvent.
        /// </summary>
        RestRequest = 16,

        /// <summary>
        /// Sends a request for selecting a unit.
        /// Selecting a unit does not mean anything to the gameplay.
        /// This is just visual representation what the opponent is doing.
        /// </summary>
        SelectUnitRequest = 17,

        /// <summary>
        /// Sends a reqquest for clearing the selection.
        /// The server will find the player current selection and clear it.
        /// It will also send notification to both players about the change.
        /// </summary>
        ClearSelectionRequest = 18,

        /// <summary>
        /// Sends entity movement request.
        /// Server should validate if movement is allowed, by executing the pathfinding again on the server.
        /// </summary>
        BattleMovementRequest = 19,

        /// <summary>
        /// Sends attack request
        /// Server should validate if attack is allowed, by checking the attack range of the attacker and the distance of the target.
        /// Both melee and ranged attacks can have range. Most of the melee attacks will have range of 1, but this will allow us to have melee attacks that is 2 or 3 range.
        /// </summary>
        BattleAttackRequest = 20,
        #endregion


        #region ServerClient

        OnAuthRequest = 100,

        OnWorldEnter = 101,

        OnMapMovement = 102,

        OnTeleport = 103,

        OnStartBattle = 104,

        OnSwitchTurn = 105,

        OnStartGame = 106,

        OnEndBattle = 107, // TODO: Delete this.

        OnReconnectBattleFail = 108,

        OnEndGame = 109,

        OnNewDay = 110,

        OnSelectUnit = 111,

        OnClearSelection = 112,

        OnBattleMovement = 113,

        OnBattleAttack = 114,

        // !!! dido I Am serializing the type as (byte). Byte max size is 126. I will probably get an error once i reach 126.

        #endregion
    }

    public interface INetPacket : INetSerializable
    {
        PacketType Type { get; }
    }
    #endregion

}
