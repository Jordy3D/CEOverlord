using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawns : MonoBehaviour {

    public Vector3[] spawnPositions;
    public GameObject obs;
    List<Vector3> takenPositions = new List<Vector3>();

    public int enemiesToSpawn;


    private void Start()
    {
        GetPositions();
        SpawnIn();
    }

    public void SpawnIn()
    {
        foreach (Vector3 position in spawnPositions)
        {
            bool willPlace = (Random.value > 0.6f);
            if (willPlace)
            {
                Instantiate(obs, position, Quaternion.identity);
                takenPositions.Add(position);
            }
        }
    }

    public void GetPositions()
    {
        int spawnCapacity = transform.childCount;
        spawnPositions = new Vector3[spawnCapacity];

        for(int i = 0; i < spawnPositions.Length; i++)
        {
            Vector3 pos = transform.GetChild(i).position;
            spawnPositions[i] = pos;
        }
    }
}
