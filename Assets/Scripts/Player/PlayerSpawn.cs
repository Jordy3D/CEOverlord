using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject player;
    public Rigidbody playerRB;
    public GameObject playerSpawnPoint;

    public int currentFloor;

    Animator bossElevator;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bossElevator = GameObject.FindGameObjectWithTag("SpawnElevator").GetComponent<Animator>();

        playerRB.position = new Vector3(0, -100, 0);
    }

    public void SpawnPlayer()
    {
        if (currentFloor == 0)
        {
            playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
            //player.transform.position = playerSpawnPoint.transform.position;
            playerRB.position = playerSpawnPoint.transform.position;
        }
        else
        {
            bossElevator.Play("ElevatorNewLevel");
            Debug.Log("Raise the roof!");
        }
    }

    public void EnablePlayer()
    {
        Debug.Log("Player Enabled");

        //player.transform.position = playerSpawnPoint.transform.position;
        playerRB.position = new Vector3(0, 1, 0);
    }
}
