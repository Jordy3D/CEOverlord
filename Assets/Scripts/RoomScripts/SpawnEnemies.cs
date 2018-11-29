using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject spawnee;
    public Transform[] spawnpoints;

    GameObject mommy;
    GameObject enemyContainer;
    GameObject doors;

    public bool isRandom;
    public int minRandom, maxRandom;

    public GameObject[] enemiesFixed;
    public GameObject[] enemyPool;

    bool hasSpawned = false;
    bool isCleared = false;
    // Use this for initialization
    void Start()
    {
        mommy = transform.parent.gameObject;

        enemyContainer = mommy.transform.Find("Enemies").gameObject;
        spawnpoints = mommy.transform.Find("EnemySpawns").GetComponentsInChildren<Transform>();

        doors = mommy.transform.Find("Doors").gameObject;
        isRandom = (Mathf.RoundToInt(Random.value) == 0);
    }

    private void Update()
    {
        if (enemyContainer.transform.childCount == 0 && hasSpawned && isCleared == false)
        {
            doors.SetActive(true);
            isCleared = true;

            int chanceToDrop = Random.Range(1, 2);
            switch (chanceToDrop)
            {
                case 1:
                    Debug.Log("You got a drop!");
                    //Vector3 dropLocation = new Vector3(mommy.transform.position.x, mommy.transform.position.y + .5f, mommy.transform.position.z);
                    GameObject clone = Instantiate(Resources.Load("Prefabs/HealthPickup"), mommy.transform) as GameObject;
                    clone.GetComponent<DropPickup>().itemID = 0;
                    
                    break;
                default:
                    Debug.Log("No drop :c");
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasSpawned == false)
        {
            Debug.Log("Ew you touched me");

            //if random is enabled or if the length of fixed spawns is not equal to the amount of spawnpoints
            if (isRandom || enemiesFixed.Length != spawnpoints.Length)
            {
                for (int i = 1; i < spawnpoints.Length; i++)
                {
                    
                    int index = Mathf.RoundToInt(Random.Range(0, enemyPool.Length - 1));

                    GameObject enemy = Instantiate(enemyPool[index], spawnpoints[i].transform.position, spawnpoints[i].transform.rotation);
                    enemy.transform.parent = enemyContainer.transform;
                }
            }
            else
            {
                Debug.Log("Fixed");
                for (int i = 1; i < spawnpoints.Length; i++)
                {
                    GameObject enemy = Instantiate(enemiesFixed[i], spawnpoints[i].transform.position, spawnpoints[i].transform.rotation);
                    enemy.transform.parent = enemyContainer.transform;
                }
            }
            hasSpawned = true;
            if (hasSpawned == true)
            {
                doors.SetActive(false);
            }
        }
    }

    public void enableDoor()
    {
        if (hasSpawned)
        {
            doors.SetActive(true);
        }
    }

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Destroy(enemyContainer);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Destroy(enemyContainer);
    //    }
    //}
}
