using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
    public GameObject explosion; //The gameobject sauce of the shake

    public CameraShake cameraShake; //The CameraShake component of the camera
    TriggerShake shake;

    // Use this for initialization
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        shake = GetComponent<TriggerShake>();

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
            other.gameObject.GetComponent<BasicEnemy>().curHealth -= PlayerManager.damage;
            Debug.Log("Did " + PlayerManager.damage + " damage to enemy");

            shake.cameraShake = cameraShake;
            shake.explosion = explosion;
            shake.StartShake(shake.shakeDuration, shake.shakeForce);
        }
    }
}
