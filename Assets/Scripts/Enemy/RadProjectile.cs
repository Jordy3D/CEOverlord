using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadProjectile : EnemyProjectile {

	 public override void Fire(Vector3 fireDir)
    {
        projectile.AddForce(fireDir * speed, ForceMode.Impulse);
    }
}
