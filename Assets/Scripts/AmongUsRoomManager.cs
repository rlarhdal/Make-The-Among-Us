using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmongUsRoomManager : NetworkRoomManager
{
    public override void OnRoomServerConnect(NetworkConnectionToClient conn)
    {
        base.OnRoomServerConnect(conn);

        Vector3 spawnPos = FindObjectOfType<SpawnPositions>().GetSpawnPosition();
        //Vector3 pos = new Vector3(0f, 0f, 0f);

        var player = Instantiate(spawnPrefabs[0], spawnPos, Quaternion.identity);
        //, spawnPos, Quaternion.identity
        NetworkServer.Spawn(player, conn);
    }
}
