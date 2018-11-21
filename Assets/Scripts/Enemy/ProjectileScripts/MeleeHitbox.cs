using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{

    public float damage;
    public float knockBack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().ChangeHealth(-damage);
            Vector3 playerBack = transform.forward;
            other.GetComponent<PlayerManager>().canMove = false;

            other.GetComponent<Rigidbody>().AddForce(playerBack.normalized * 5f, ForceMode.Impulse);
            StartCoroutine(other.GetComponent<CharacterMovement>().EnableInput(0.4f));
            //other.GetComponent<Rigidbody>().MovePosition(other.transform.position - playerBack*5f);
        }
    }
}
