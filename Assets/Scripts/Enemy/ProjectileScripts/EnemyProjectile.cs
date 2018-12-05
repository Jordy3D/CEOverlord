using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyProjectile : MonoBehaviour
{


    public float damage;
    public Rigidbody projectile;
    public float speed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Fire(Vector3 fireDir)
    {
        projectile.AddForce(fireDir * speed, ForceMode.Impulse);
    }

    
}
