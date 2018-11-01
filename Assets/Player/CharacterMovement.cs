using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody playerRB;
    //references the rigidbody for the player

    public float health;
    public float moveSpeed;
    public float damage;
    public float attackSpeed;
    public float attackRange;

    PlayerStats stats;
    DisplayStats display;

    public void Start()
    {
        //gets and attaches the rigidbody
        playerRB = GetComponent<Rigidbody>();
        //constains the x rotation, z rotation and y position
        playerRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //main camera is equal to the camera in the scene

        stats = GetComponent<PlayerStats>();

       

        UpdateStats();

        display = GameObject.Find("GamePanel").GetComponent<DisplayStats>();
    }

    // Update is called once per frame
    public void Update()
    {
        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 moveDir = new Vector3(inputH, 0f, inputV) * moveSpeed;
        Vector3 force = new Vector3(moveDir.x, playerRB.velocity.y, moveDir.z);
        playerRB.velocity = force;
    }

    void OnTriggerStay(Collider enemy)
    {
        //if the players collider touches the enemy's collider and isShadow = true
        if (enemy.gameObject.tag == "Enemy")
        {

            Debug.Log("Entered wrong house fool");
        }
    }

    public void UpdateStats()
    {
        health = stats.health;
        moveSpeed = stats.moveSpeed;
        damage = stats.damage;
        attackSpeed = stats.attackSpeed;
        attackRange = stats.attackRange;

        display.UpdateDisplay();
    }
}
