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
    public Vector3 agentTarget;
    public float health = 5f;
    public bool canFire = true;
    public float timer = 0f;
    public float attackDelay;
    public Behaviour state;
    public float maxHealth = 10f;
    public float curHealth;
    public bool canAct = true;


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
        if (canAct)
        {
            if (enemyAttack.GetComponent<CultistMelee>())
            {
                if (player != null)
                {
                    agentTarget = player.position;
                    if (Vector3.Distance(transform.position, player.position) < 2f)
                    {
                        //will rig enemy attack with a delay before punching to warn player
                        if (canFire)
                        {
                            enemyAttack.Attack();
                            canFire = false;
                        }
                    }
                }
            }
            else if (enemyAttack.GetComponent<CultistAttack>())
            {
                Vector3 vel = player.position - transform.position;
                vel.Normalize();
                Vector3 moveDir = vel * -1;
                agentTarget = transform.position + moveDir * Time.deltaTime;

                //transform.rotation = Quaternion.LookRotation(new Vector3(player.position.x, 0f, player.position.z), Vector3.up);
                if (canFire)
                {
                    enemyAttack.Attack();
                    canFire = false;
                }
            }
            else if (enemyAttack.GetComponent<BossAttack>())
            {
                if (canFire)
                {
                    enemyAttack.Attack();
                    canFire = false;
                }
            } 
        }

        #endregion


        

        if (health > 0)
        {
            healthBar.fillAmount = curHealth / maxHealth;
            me.SetDestination(agentTarget);
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