using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject player;
    public Rigidbody playerRB;
    public GameObject playerSpawnPoint;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlayer()
    {
        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
        //player.transform.position = playerSpawnPoint.transform.position;
        playerRB.position = playerSpawnPoint.transform.position;
    }
}
