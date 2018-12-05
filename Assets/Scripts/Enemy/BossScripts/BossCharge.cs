using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCharge : EnemyAttack
{

    public Vector3 playerPos;
    Vector3 moveDir;
    Vector3 targetPos;
    public bool isCharging;
    BossEnemy boss;
    public float chargeSpeed;
    public float rayDistance = 100f;
    public float speedModifier = 7f;
    public LayerMask ignoreLayers;
    public NavMeshAgent agent;
    public Collider chargeHit;
    public Material[] mats;


    private void Start()
    {
        boss = GetComponent<BossEnemy>();
        agent = GetComponent<NavMeshAgent>();
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
            targetPos = hit.point - moveDir.normalized * 2f;
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
        boss.transform.LookAt(targetPos);
        boss.canAct = false;
        StartCoroutine(TelegraphCharge());
    }

    private void Update()
    {
        if (isCharging)
        {
            agent.speed *= speedModifier;
            agent.SetDestination(targetPos);
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, chargeSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 1f)
            {
                isCharging = false;
                boss.canAct = true;
                boss.GetComponent<Rigidbody>().isKinematic = true;
                agent.speed /= speedModifier;
                chargeHit.enabled = false;
                GetComponent<Renderer>().material = mats[0];
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
            chargeHit.enabled = false;
        }
    }

    IEnumerator TelegraphCharge()
    {
        float time = Time.time;
        bool flash = false;
        while (Time.time < time + 0.5f)
        {
            if (flash)
            {
                GetComponent<Renderer>().material = mats[1];
                flash = !flash;
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                GetComponent<Renderer>().material = mats[0];
                flash = !flash;
                yield return new WaitForSeconds(0.2f);
            }
        }
        GetComponent<Renderer>().material = mats[1];
        isCharging = true;
        chargeHit.enabled = true;
    }
}
