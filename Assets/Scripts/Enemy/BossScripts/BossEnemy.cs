using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemy : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public EnemyAttack[] attacks;
    public EnemyAttack currentAttack;
    public float health;
    public float timer;
    public float delay;
    bool canAttack = true;
    public bool canAct, activated;
    public bool belowHalf;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attacks = GetComponents<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canAct && activated)
        {
            //run timer to see if we can attack
            if (canAttack == false)
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    canAttack = true;
                    timer = 0f;
                }
            }
            else
            {

                int attackIndex = Mathf.RoundToInt(Random.Range(0, attacks.Length));
                currentAttack = attacks[attackIndex];
                canAttack = false;
                delay = currentAttack.delay;
                if (currentAttack == attacks[0])
                {
                    BossCharge chargeAttack = currentAttack.GetComponent<BossCharge>();
                    chargeAttack.Attack();
                    canAct = false;
                }
                else if (currentAttack == attacks[1])
                {
                    BossRadial radialAttack = currentAttack.GetComponent<BossRadial>();
                    radialAttack.CallMulti(5);
                    canAct = false;
                }

            }
        }
    }


}
