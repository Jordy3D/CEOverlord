using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CultistMelee : EnemyAttack
{

    public NavMeshAgent agent;
    public SphereCollider hitbox;
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
        StartCoroutine(DeactivateHitbox());

    }

    IEnumerator DeactivateHitbox()
    {

        yield return new WaitForSeconds(0.4f);
        //hitbox.gameObject.SetActive(false);
        hitbox.enabled = false;
        agent.isStopped = false;
    }
}
