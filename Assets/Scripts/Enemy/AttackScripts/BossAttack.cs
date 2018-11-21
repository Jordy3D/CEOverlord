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
            Debug.Log(currentAngle);
            float x = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            float y = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float dirX = x * radius;
            float dirY = y * radius;
            Vector3 shotDir = new Vector3(dirX, 0f, dirY);
            Vector3 shotMoveDir = (shotDir).normalized;

            GameObject clone = Instantiate(projectile, startPoint, Quaternion.identity);
            EnemyProjectile newProjectile = clone.GetComponent<EnemyProjectile>();

            print(new Vector3(shotMoveDir.x, 0f, shotMoveDir.z));
            newProjectile.Fire(new Vector3(shotMoveDir.x, 0, shotMoveDir.z));
            
            currentAngle += angleStep;
            
        }
        Debug.Log("Reached nums - 1");
    }
}
