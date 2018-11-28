using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : EnemyAttack
{

    public Vector3 playerPos;
    Vector3 moveDir;
    Vector3 targetPos;
    public bool isCharging;
    BossEnemy boss;
    public float chargeSpeed;
    public float rayDistance = 100f;
    public LayerMask ignoreLayers;

    private void Start()
    {
        boss = GetComponent<BossEnemy>();
    }

    private void OnDrawGizmos()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + moveDir.normalized * rayDistance;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(start, end);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(targetPos, 1f);
    }

    public override void Attack()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        Vector3 bossPos = transform.position;

        //have to use transform position y to stop it from sinking into ground

        // Get direction from boss to player
        moveDir = new Vector3(playerPos.x, 0, playerPos.z) - new Vector3(bossPos.x, 0, bossPos.z);
      //  moveDir = moveDir.normalized; // Normalize it 'correctly'
        // Get target position including boss's y
        
        RaycastHit hit;
        // Raycast towards the target
        if (Physics.Raycast(bossPos, moveDir.normalized, out hit, rayDistance, ~ignoreLayers))
        {
            // Move the hit point away from the wall
            targetPos = hit.point - moveDir.normalized * -2f;
            // Setting the Y the same as the boss
            targetPos.y = bossPos.y;
        }
        //else // If the boss doesn't hit anything
        //{
        //    // Negating target pos
        //    targetPos *= -9f;
        //    // Set Y the same as Boss Y
        //    targetPos.y = bossPos.y;
        //}

        Debug.Log("Target Pos: " + targetPos);
        isCharging = true;
        boss.canAct = false;
        boss.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Update()
    {
        if (isCharging)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPos, chargeSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 1f)
            {
                isCharging = false;
                boss.canAct = true;
                boss.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Hit Player");
        }
        else if (collision.gameObject.tag == "Ground")
        {

        }
        else
        {
            Debug.Log("Hit Wall");
            boss.canAct = true;
            //targetPos = Vector3.zero;
            boss.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
