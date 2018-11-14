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

    bool hasSpawned = false;
    // Use this for initialization
    void Start()
    {
        mommy = transform.parent.gameObject;

        enemyContainer = mommy.transform.Find("Enemies").gameObject;
        spawnpoints = mommy.transform.Find("EnemySpawns").GetComponentsInChildren<Transform>();
        
        doors = mommy.transform.Find("Doors").gameObject;
    }

    private void Update()
    {
        if (enemyContainer.transform.childCount == 0 && hasSpawned)
        {
            doors.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasSpawned == false)
        {
            Debug.Log("Ew you touched me");
            for (int i = 0; i < spawnpoints.Length; i++)
            {
                Debug.Log("Spawned" + spawnee.name);
                GameObject enemy = Instantiate(spawnee, spawnpoints[i].transform.position, spawnpoints[i].transform.rotation);
                enemy.transform.parent = enemyContainer.transform;
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
