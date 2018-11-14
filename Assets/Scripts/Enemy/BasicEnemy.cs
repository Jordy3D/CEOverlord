using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public NavMeshAgent me;
    public Transform player;
    public EnemyAttack enemyAttack;
    public float health = 10f;
    bool canFire = true;
    float timer = 0f;

    public float maxHealth = 10f;
    public float curHealth;

    public Image healthBar;

    // Use this for initialization
    void Start()
    {
        me = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enemyAttack = GetComponent<EnemyAttack>();


        curHealth = maxHealth;

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

        healthBar.fillAmount = curHealth / maxHealth;
        me.SetDestination(player.position);
        if(curHealth < 0)

        {
            curHealth = 0;
        }

        if(curHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}