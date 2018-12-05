using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTrigger : MonoBehaviour
{
    Animator bossElevator;

    public GameObject healthBarHolder;
    public Image healthBar;

    public GameObject nextFloorObject;

    private void Awake()
    {
        healthBarHolder = null;
        healthBar = null;
    }

    // Use this for initialization
    void Start()
    {
        bossElevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Animator>();

        healthBarHolder = GameObject.Find("BossHealthBar"); //Trigger
        healthBar = healthBarHolder.transform.Find("HealthAmount").GetComponent<Image>();

        healthBarHolder.SetActive(false);

        nextFloorObject = GameObject.Find("NextFloor");
        nextFloorObject.SetActive(false);
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
