using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitboxDamage : MonoBehaviour
{

    public GameObject explosion; //The gameobject sauce of the shake

    public CameraShake cameraShake; //The CameraShake component of the camera
    TriggerShake shake;
    public float currentKnockBack;
    float deafaultKnockBack = 5f;
    IEnumerator instance;
    bool isRunning;

    // Use this for initialization
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        shake = GetComponent<TriggerShake>();
        //to be multiplied from player attack
        currentKnockBack = deafaultKnockBack;
        explosion = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {


            shake.cameraShake = cameraShake;
            shake.explosion = explosion;
            shake.StartShake(shake.shakeDuration, shake.shakeForce);
            KnockBack(currentKnockBack, other.gameObject);
            other.gameObject.GetComponent<BasicEnemy>().curHealth -= PlayerManager.damage;
            Debug.Log("Did " + PlayerManager.damage + " damage to enemy");
        }
    }


    //this might be the problem
    IEnumerator ResetKinematic(Rigidbody rb, Vector3 vel)
    {
        //float time = Time.time;
        //Vector3 destination = transform.position + vel * 0.2f;
        //Debug.Log(destination + "Is predicted destination");
        //Vector3 startPos = rb.position;
        //while (Time.time < time + 0.2f)
        //{
        //    rb.position = Vector3.Lerp(startPos, destination, (Time.time - time) / 0.2f);
        //    yield return null;
        //}
        isRunning = true;
        yield return new WaitForSeconds(0.2f);
        rb.isKinematic = true;
        rb.GetComponent<BasicEnemy>().canAct = true;
        isRunning = false;

    }

    public void KnockBack(float forceMultiplier, GameObject enemy)
    {
        enemy.GetComponent<BasicEnemy>().canAct = false;
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(enemy.transform.forward * currentKnockBack * -1, ForceMode.Impulse);
        // enemy.GetComponent<NavMeshAgent>().velocity = rb.velocity;
        Vector3 vel = ((enemy.transform.forward * currentKnockBack * -1) / rb.mass) * Time.fixedDeltaTime;
        Debug.Log("Rb velocity is " + rb.velocity);
        Debug.Log("Rb velocity should be " + vel);

        if (isRunning)
        {
            StopCoroutine(ResetKinematic(rb, vel));
            isRunning = false;
        }

        StartCoroutine(ResetKinematic(rb, vel));
        //reset the knockback
        currentKnockBack = deafaultKnockBack;
        
    }

   
}
