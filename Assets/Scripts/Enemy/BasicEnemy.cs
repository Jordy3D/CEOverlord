using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public NavMeshAgent me;
    public Transform player;
    public float maxHealth = 10f;
    public float curHealth;

    public Image healthBar;
    // Use this for initialization
    void Start()
    {
        me = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = curHealth / maxHealth;
        me.SetDestination(player.position);
        if(curHealth < 0)
        {
            curHealth = 0;
        }

        if(curHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}