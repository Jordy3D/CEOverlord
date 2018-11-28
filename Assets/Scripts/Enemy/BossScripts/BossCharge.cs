using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : EnemyAttack {

    public Vector3 playerPos;
    Vector2 moveDir, targetPos;
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
        moveDir = new Vector2(boss.transform.position.x, boss.transform.position.z) - new Vector2(playerPos.x, playerPos.z);
        moveDir = moveDir / moveDir.magnitude;
        targetPos = moveDir * -10f;
        Debug.Log("Target Pos: " + targetPos);
        isCharging = true;
        boss.canAct = false;
        boss.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Update()
    {
        if (isCharging)
        {
            Vector3 destination = new Vector3(moveDir.x, boss.transform.position.y, moveDir.y);
            boss.transform.position = Vector3.MoveTowards(transform.position, destination * -10f, chargeSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPos) < 1f)
            {
                isCharging = false;
                boss.canAct = true;
                moveDir = Vector3.zero;
                targetPos = Vector3.zero;
                boss.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Hit Player");
        } else if(collision.gameObject.tag == "Ground")
        {
            
        }
        else
        {
            Debug.Log("Hit Wall");
            isCharging = false;
            boss.canAct = true;
            moveDir = Vector3.zero;
            targetPos = Vector3.zero;
            boss.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
