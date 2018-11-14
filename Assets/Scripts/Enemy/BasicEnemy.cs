using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public NavMeshAgent me;
    public Transform player;
    public EnemyAttack enemyAttack;
    public float health = 10f;
    bool canFire = true;
    float timer = 0f;
    // Use this for initialization
    void Start()
    {
        me = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canFire == false)
        {
            timer += Time.deltaTime;
            if(timer >= 0.7f)
            {
                canFire = true;
            }
        }

        me.SetDestination(player.position);
        //maybe this line??
        me.transform.LookAt(player.position);
        if (canFire)
        {
            enemyAttack.Attack();
        }
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