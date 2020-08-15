using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour {
    private PlayerController player;
    public string spawnName;


    public Vector2 facingDirection;
    void Start() {
        player = FindObjectOfType<PlayerController>();

        if(player.nextSpawnName == spawnName) {
            player.transform.position = this.transform.position;
            player.lastMove = facingDirection;
        }
    }
}
