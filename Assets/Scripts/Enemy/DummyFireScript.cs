using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyFireScript : MonoBehaviour {

    public EnemyAttack attack;
    public float delay;
    public float timer;
    public bool canFire = false;


	// Use this for initialization
	void Start () {
        attack = GetComponent<EnemyAttack>();
        delay = attack.delay;
	}
	
	// Update is called once per frame
	void Update () {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer >= delay)
            {
                canFire = true;
                timer = 0f;
            }
        } else
        {
            attack.Attack();
            canFire = false;
        }
	}
}
