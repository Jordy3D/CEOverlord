using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    TriggerShake shake;

    public GameObject explosion; //The ParticleSystem component of the explosion object
    public CameraShake cameraShake; //The CameraShake component of the camera

    GameObject player;
    PlayerSpawn playerSpawn;

    // Use this for initialization
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawn = player.GetComponent<PlayerSpawn>();

        shake = GetComponent<TriggerShake>();
        explosion = this.gameObject;
    }

    public void OnLand()
    {
        shake.cameraShake = cameraShake;
        shake.explosion = explosion;
        shake.StartShake(shake.shakeDuration, shake.shakeForce);
    }

    public void EnablePlayer()
    {
        playerSpawn.EnablePlayer();
    }

    public void SpawnBoss()
    {
        Vector3 bossPos = GameObject.Find("Boss").transform.position;
        Destroy(GameObject.Find("Boss"));
        GameObject boss = Instantiate(Resources.Load("Prefabs/Enemies/Boss") as GameObject, bossPos, Quaternion.identity);
        boss.GetComponent<BossEnemy>().activated = true;

    }
}
