using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : EnemyProjectile
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerManager>().ChangeHealth(-damage);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(other.collider, this.GetComponent<Collider>());
            return;
        }
        Destroy(this.gameObject);
    }


}
