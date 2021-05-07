using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pongbat
{
    public class PongbatNetworkManager : NetworkManager
    {
        [SerializeField] Transform leftRacketSpawn = null;
        [SerializeField] Transform rightRacketSpawn = null ;
        [SerializeField] Transform ballSpawn = null;
        GameObject ball;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            GameObject paddle = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Paddle"), start.position, start.rotation);
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);
            NetworkServer.Spawn(paddle, conn);
            //player.GetComponent<PlayerInput>().SetPlayerPaddle(paddle);

            // spawn ball if two players
            if (numPlayers == 2)
            {
                ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"), ballSpawn);
                NetworkServer.Spawn(ball);
            }
        }
    }
}


