using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack{

    public int numProjectiles;
    public float radius;
    

	// Use this for initialization
	void Start () {
        state = Behaviour.Sentinal;
	}
	
	

    public override void Attack()
    {
        //number of turns we need to make for radial attack
        Vector3 startPoint = this.transform.position;
        float angleStep = 360 / numProjectiles;
        //Debug.Log(angleStep);
        float currentAngle = 0f;

        for (int i = 0; i < numProjectiles; i++)
        {
            float x = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            float y = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float dirX = x * radius;
            float dirY = y * radius;
            Vector3 shotDir = new Vector3(dirX, 0f, dirY);

            GameObject clone = Instantiate(projectile, startPoint, Quaternion.identity);
            EnemyProjectile newProjectile = clone.GetComponent<EnemyProjectile>();

            newProjectile.Fire(shotDir.normalized);
            
            currentAngle += angleStep;
            
        }
        Debug.Log("Reached nums - 1");
    }
}
