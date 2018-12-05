using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadProjectile : EnemyProjectile
{

    public override void Fire(Vector3 fireDir)
    {
        Debug.Log("Fire in the hole!");
        projectile.AddForce(fireDir * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().ChangeHealth(-1);
            Destroy(this.gameObject);
        }
        else if (!(other.tag == "Enemy" || other.tag == "Projectile" || other.tag == "Boss" || other.name == "Ground"))
        {
            Destroy(this.gameObject);
            Debug.Log("I hit a " + other.name);
            return;
        }
        else
        {
            //Destroy(this.gameObject);
        }


        //if (other.tag == "Player")
        //{
        //    other.GetComponent<PlayerManager>().ChangeHealth(-damage);
        //    //Destroy(this.gameObject);
        //    return;
        //}

        //if (other.tag != "Enemy")
        //{
        //    //Destroy(this.gameObject);
        //}
        //else if (other.tag != "Projectile")
        //{
        //    //Destroy(this.gameObject);
        //}
    }
}
