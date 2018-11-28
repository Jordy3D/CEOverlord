using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : EnemyAttack {

    public Vector3 playerPos;
    Vector3 moveDir, targetPos;
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
        //have to use transform position y to stop it from sinking into ground
        moveDir = (new Vector3(transform.position.x, 0f, transform.position.z) - new Vector3(playerPos.x, 0f, playerPos.z)).normalized * -1f;
        moveDir.y = 0;
        targetPos = moveDir * 10f;
        Debug.Log("Target Pos: " + targetPos);
        isCharging = true;
        boss.canAct = false;
    }

    private void Update()
    {
        if (isCharging)
        {

            boss.transform.position = Vector3.MoveTowards(transform.position, moveDir * 10f, chargeSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPos) < 1f)
            {
                isCharging = false;
                boss.canAct = true;
                moveDir = Vector3.zero;
                targetPos = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Hit Player");
        }
        else
        {
            Debug.Log("Hit Wall");
            isCharging = false;
            boss.canAct = true;
            moveDir = Vector3.zero;
            targetPos = Vector3.zero;
        }
    }
}
