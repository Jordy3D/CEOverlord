using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCol : MonoBehaviour {

    Collider enemyCol;

    private void Start()
    {
        enemyCol = transform.parent.GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Physics.IgnoreCollision(other, enemyCol);
        }
    }
}
