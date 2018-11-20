using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistAttack : EnemyAttack
{
    private void Start()
    {
        state = Behaviour.Flee;
    }
    public override void Attack()
    {
        Vector3 forward = transform.forward;
        GameObject clone = Instantiate(projectile, spawn.position, spawn.rotation);
        BasicProjectile proj = clone.GetComponent<BasicProjectile>();
        proj.Fire(forward);
    }
}
