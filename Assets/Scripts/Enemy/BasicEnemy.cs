using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public NavMeshAgent me;
    public Transform player;
<<<<<<< HEAD
    public EnemyAttack enemyAttack;
    public float health = 10f;
    bool canFire = true;
    float timer = 0f;
=======
    public float maxHealth = 10f;
    public float curHealth;

    public Image healthBar;
>>>>>>> fa432726b140f745f714579d0997282503cd6a10
    // Use this for initialization
    void Start()
    {
        me = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
<<<<<<< HEAD
        enemyAttack = GetComponent<EnemyAttack>();
=======

        curHealth = maxHealth;
>>>>>>> fa432726b140f745f714579d0997282503cd6a10
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
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
=======
        healthBar.fillAmount = curHealth / maxHealth;
        me.SetDestination(player.position);
        if(curHealth < 0)
>>>>>>> fa432726b140f745f714579d0997282503cd6a10
        {
            curHealth = 0;
        }

        if(curHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}