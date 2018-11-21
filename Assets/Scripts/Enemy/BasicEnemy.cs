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
    public bool canFire = true;
    public float timer = 0f;
    public float attackDelay;
    public Behaviour state;
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
        attackDelay = enemyAttack.delay;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (canFire == false)
        {
            timer += Time.deltaTime;
            if (timer >= attackDelay)
            {
                canFire = true;
                timer = 0;
            }
        }
        #region PossibleStateCode
        /*
        
        if (state == Behaviour.Seek)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) > 1f)
            {
                me.SetDestination(player.position);
            }

            if (Vector3.Distance(this.transform.position, player.transform.position) <= 1f)
            {
                if (canFire)
                {
                    enemyAttack.Attack();
                    canFire = false;
                }
            }

        }
        else if (state == Behaviour.Flee)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) <= 3f)
            {
                // me.SetDestination(player.position);
                me.SetDestination((this.transform.position - player.transform.position) * 3f);
            }

            if (Vector3.Distance(this.transform.position, player.transform.position) > 3f)
            {
                me.SetDestination(player.transform.position);

            }

            if (canFire)
            {
                enemyAttack.Attack();
                canFire = false;
            }
        }
        else if (state == Behaviour.Sentinal)
        {

        } 
        */
        #endregion


        if (canFire)
        {
            enemyAttack.Attack();
            canFire = false;
        }

        if (health > 0)
        {
            healthBar.fillAmount = curHealth / maxHealth;
            me.SetDestination(player.position);
        }

        if (curHealth < 0)
        {
            curHealth = 0;
        }

        if (curHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

   
}

public enum Behaviour
{
    Seek,
    Flee,
    Sentinal
}