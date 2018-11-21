using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRadial : EnemyAttack {

    public float radius;
    public int numProjectiles;
    public BossEnemy boss;

    private void Start()
    {
        boss = GetComponent<BossEnemy>();
        
        
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
            float dirX = startPoint.x + Mathf.Sin((currentAngle * Mathf.PI) / 180) * radius;
            float dirY = startPoint.y + Mathf.Cos((currentAngle * Mathf.PI) / 180) * radius;
            Vector3 shotDir = new Vector3(dirX, dirY, 0f);
            Vector3 shotMoveDir = (shotDir - startPoint).normalized;

            GameObject clone = Instantiate(projectile, startPoint, Quaternion.identity);
            EnemyProjectile newProjectile = clone.GetComponent<EnemyProjectile>();

            newProjectile.Fire(new Vector3(shotMoveDir.x, 0, shotMoveDir.y));

            currentAngle += angleStep;

        }
        Debug.Log("Reached nums - 1");
    }

    public void AttackMulti(float angleShift)
    {
        //number of turns we need to make for radial attack
        Vector3 startPoint = this.transform.position;
        float angleStep = 360 / numProjectiles;
        //Debug.Log(angleStep);
        float currentAngle = angleShift;

        for (int i = 0; i < numProjectiles; i++)
        {
            Debug.Log(currentAngle);
            float dirX = startPoint.x + Mathf.Sin((currentAngle * Mathf.PI) / 180) * radius;
            float dirY = startPoint.y + Mathf.Cos((currentAngle * Mathf.PI) / 180) * radius;
            Vector3 shotDir = new Vector3(dirX, dirY, 0f);
            Vector3 shotMoveDir = (shotDir - startPoint).normalized;

            GameObject clone = Instantiate(projectile, startPoint, Quaternion.identity);
            EnemyProjectile newProjectile = clone.GetComponent<EnemyProjectile>();

            newProjectile.Fire(new Vector3(shotMoveDir.x, 0, shotMoveDir.y));

            currentAngle += angleStep;

        }
        Debug.Log("Reached nums - 1");
    }

    IEnumerator radialMulti(int repeats, float shift)
    {
        float angleShift = 0f;
        for (int i = 0; i < repeats; i++)
        {
            AttackMulti(angleShift);
            angleShift += shift;
            yield return new WaitForSeconds(0.7f); 
        }
        boss.canAct = true;
    }

    public void CallMulti(int repeats)
    {
        
        StartCoroutine(radialMulti(repeats, 15f));
    }
}
