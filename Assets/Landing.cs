using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    TriggerShake shake;

    public GameObject explosion; //The ParticleSystem component of the explosion object
    public CameraShake cameraShake; //The CameraShake component of the camera

    // Use this for initialization
    void Start()
    {
        shake = GetComponent<TriggerShake>();
        explosion = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLand()
    {
        shake.cameraShake = cameraShake;
        //shake.explosion = explosionEffect;
        shake.StartShake(shake.shakeDuration, shake.shakeForce);
    }
}
