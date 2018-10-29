using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    GameObject player;
    Transform playerSpawnPoint;
    
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPlayer()
    {
        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn").GetComponent<Transform>();
        player.transform.position = playerSpawnPoint.position;
    }
}
