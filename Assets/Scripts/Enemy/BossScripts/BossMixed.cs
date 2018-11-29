using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMixed : EnemyAttack {

    BossRadial radial;
    BossCharge charge;
    int cycles;
	// Use this for initialization
	void Start () {
        radial = GetComponent<BossRadial>();
        charge = GetComponent<BossCharge>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        StartCoroutine(AttackCycle());
    }

    public IEnumerator AttackCycle()
    {
        for (int i = 0; i < cycles; i++)
        {
            charge.Attack();
            while (charge.isCharging != false)
            {
                yield return null;
            }
            radial.Attack();

        }
        
    }
    
}
