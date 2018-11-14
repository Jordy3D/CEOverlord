using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public NavMeshAgent me;
    public Transform player;
    public float health = 10f;
    // Use this for initialization
    void Start()
    {
        me = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        me.SetDestination(player.position);
        if(health < 0)
        {
            health = 0;
        }

        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}