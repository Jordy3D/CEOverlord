using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : EnemyProjectile {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().ChangeHealth(-damage);
        }
        Destroy(this.gameObject);
    }
}
