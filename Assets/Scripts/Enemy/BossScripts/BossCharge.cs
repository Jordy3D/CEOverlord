using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : EnemyAttack {

    public Vector3 playerPos;
    public bool isCharging;
    BossEnemy boss;
    public float chargeSpeed;

    private void Start()
    {
        boss = GetComponent<BossEnemy>();
    }

    public override void Attack()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        isCharging = true;
        boss.canAct = false;
    }

    private void Update()
    {
        if (isCharging)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, playerPos, chargeSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, playerPos) < 1f)
            {
                isCharging = false;
                boss.canAct = true;
            }
        }
    }
}
