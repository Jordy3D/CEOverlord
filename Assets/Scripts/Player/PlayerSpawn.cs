using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject player;
    public Rigidbody playerRB;
    public GameObject playerSpawnPoint;

    public int currentFloor;

    public Animator spawnElevator;

    public CurrentLevelStats level;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();

        playerRB.position = new Vector3(0, -100, 0);

        //bossElevator = GameObject.FindGameObjectWithTag("SpawnElevator").GetComponent<Animator>();
    }

    private void Start()
    {

        level = GameObject.Find("CurrentLevelManager").GetComponent<CurrentLevelStats>();
        currentFloor = level.currentLevel;

        spawnElevator = GameObject.FindGameObjectWithTag("SpawnElevator").GetComponent<Animator>();

        if (currentFloor != level.currentLevel)
        {
            currentFloor = level.currentLevel;
        }
    }

    public void SpawnPlayer()
    {
        spawnElevator = GameObject.FindGameObjectWithTag("SpawnElevator").GetComponent<Animator>();

        Debug.Log("Spawning the player into " + currentFloor);
        if (currentFloor == 0)
        {
            playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
            //player.transform.position = playerSpawnPoint.transform.position;
            playerRB.position = playerSpawnPoint.transform.position;
        }
        else
        {
            spawnElevator = GameObject.FindGameObjectWithTag("SpawnElevator").GetComponent<Animator>();

            spawnElevator.Play("ElevatorNewLevel");
            Debug.Log("Raise the roof!");
        }
    }

    private void Update()
    {
        if (currentFloor != level.currentLevel)
        {
            currentFloor = level.currentLevel;
        }
    }

    public void EnablePlayer()
    {
        Debug.Log("Player Enabled");

        //player.transform.position = playerSpawnPoint.transform.position;
        playerRB.position = new Vector3(0, 1, 0);
    }
}