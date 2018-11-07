﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    Animator bossElevator;
    // Use this for initialization
    void Start()
    {
        bossElevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossElevator.Play("ElevatorDrop");
            Debug.Log("Bass Dropped");
        }
    }

}
