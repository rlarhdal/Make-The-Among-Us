using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyCharacterMover : CharacterMover
{
    [SyncVar(hook = nameof(SetOwnedNetId_Hook))]
    public uint ownerNetId;
    public void SetOwnedNetId_Hook(uint _, uint newOwnerId)
    {
        var players = FindObjectOfType<AmongUsRoomPlayer>();
        foreach(var player in players)
        {
            if(newOwnerId == player.netId)
            {
                player.lobbyPlayerCharacter = this;
                break;
            }
        }
    }
    public void CompleteSpawn()
    {
        if(isOwned)
        {
            isMoveable = true;
        }
    }
}
