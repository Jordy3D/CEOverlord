using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CultistMelee : EnemyAttack
{

    public NavMeshAgent agent;
    public SphereCollider hitbox;
    public GameObject fist;
    public GameObject startP, endP;
    bool isPunching;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hitbox = projectile.GetComponent<SphereCollider>();
        state = Behaviour.Seek;
    }

    

    public override void Attack()
    {
        agent.isStopped = true;
        hitbox.enabled = true;
        StartCoroutine(punchingLerp(0.2f));
        StartCoroutine(DeactivateHitbox());

    }

    

    IEnumerator DeactivateHitbox()
    {

        yield return new WaitForSeconds(0.4f);
        //hitbox.gameObject.SetActive(false);
        hitbox.enabled = false;
        agent.isStopped = false;
    }

    IEnumerator punchingLerp(float punchTime)
    {
        float time = Time.time;
        while(Time.time < time + punchTime/2)
        {
            fist.transform.position = Vector3.Lerp(startP.transform.position, endP.transform.position, (Time.time - time) / (punchTime/2));
            yield return null;
        }
        time = Time.time;
        while (Time.time < time + punchTime / 2)
        {
            fist.transform.position = Vector3.Lerp(endP.transform.position, startP.transform.position, (Time.time - time) / (punchTime / 2));
            yield return null;
        }
        fist.transform.position = startP.transform.position;
    }
}
