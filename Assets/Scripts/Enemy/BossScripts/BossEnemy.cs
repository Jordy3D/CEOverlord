﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public EnemyAttack[] attacks;
    public EnemyAttack currentAttack;
    public float health, curHealth;
    public float timer;
    public float delay;
    bool canAttack = true;
    public bool canAct, activated;
    public bool belowHalf;

    public GameObject healthBarHolder;
    public Image healthBar;

    public GameObject nextFloorObject;

    public GameObject bossFloor;
    public GameObject bossGround;

    private void Awake()
    {
        healthBarHolder = null;
        healthBar = null;
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attacks = GetComponents<EnemyAttack>();
        curHealth = health;

        bossFloor = GameObject.Find("Cell_Boss(Clone)");
        bossGround = bossFloor.transform.Find("Ground").gameObject;

        healthBar = bossGround.GetComponent<BossTrigger>().healthBar;
        healthBarHolder = bossGround.GetComponent<BossTrigger>().healthBarHolder;

        healthBar.fillAmount = health;
        healthBarHolder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = curHealth / health;

        if (curHealth <= 0)
        {
            Death();
        }

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

                if (!belowHalf)
                {
                    int attackIndex = Mathf.RoundToInt(Random.Range(0, attacks.Length - 1));
                    currentAttack = attacks[attackIndex];
                    canAttack = false;
                    delay = currentAttack.delay;
                    if (currentAttack == attacks[0])
                    {
                        Debug.Log("Charging");
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
                else
                {
                    int attackIndex = Mathf.RoundToInt(Random.Range(0, attacks.Length - 1));
                    currentAttack = attacks[attackIndex];
                    canAttack = false;
                    delay = currentAttack.delay / 2;
                    if (currentAttack == attacks[0])
                    {
                        Debug.Log("Charging");
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

        if (curHealth <= health / 2)
        {
            belowHalf = true;
        }

        
    }
    public void Death()
    {
        Destroy(this.gameObject);

        bossGround.GetComponent<BossTrigger>().nextFloorObject.SetActive(true);
    }


}
