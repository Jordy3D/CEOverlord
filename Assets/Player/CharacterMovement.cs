using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody playerRB;
    //references the rigidbody for the player

    public static float health;
    public float moveSpeed;
    public static float damage;
    public float attackSpeed;
    public float attackRange;
    public float stamina;
    public static bool canRegen = true;
    public float regenRate;
    public float dashTime = 0f;

    PlayerStats stats;
    DisplayStats display;

    bool isCoRunning = false;

    public bool isDashing = false;
    
    public void Start()
    {
        //gets and attaches the rigidbody
        playerRB = GetComponent<Rigidbody>();
        //constains the x rotation, z rotation and y position
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        //main camera is equal to the camera in the scene

        stats = GetComponent<PlayerStats>();

        display = GameObject.Find("GamePanel").GetComponent<DisplayStats>();

        UpdateStats();
    }


    private void Update()
    {
        if (isDashing)
        {
            dashTime += Time.deltaTime;
            if(dashTime > 0.2f)
            {
                isDashing = false;
                dashTime = 0;
            }
        }
    }
    // Update is called once per frame
    public void FixedUpdate()
    {



        if (canRegen)
        {
            Regen();
            if (stamina > 100)
            {
                stamina = 100;
            }
        }

        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;


        Vector3 moveDir = new Vector3(inputH, 0f, inputV) * moveSpeed;
        Vector3 force = new Vector3(moveDir.x, playerRB.velocity.y, moveDir.z);

        //if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0)
        //{
        //    playerRB.AddForce(force * 10f, ForceMode.Impulse);

        //    Vector3 newPosition = force * 10f;
        //    // Use new position to lerp

        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0 && !isDashing)
        {
            playerRB.velocity = Vector3.zero;

            stamina -= 20f;
            if (stamina < 0)
            {
                stamina = 0;
                Debug.Log("Out of stamina");
            }
            canRegen = false;

            

            CallRegenStam();

            isDashing = true;
        }

        if (isDashing)
        {
            force = force * 2f;
            dashTime += Time.deltaTime; 
        }

        playerRB.velocity = force;

        if (playerRB.velocity != Vector3.zero)
        {
            playerRB.rotation = Quaternion.LookRotation(playerRB.velocity);
        }

        if (stamina < 0)
        {
            stamina = 0;
        }

        //update the display
        display.UpdateDisplay();
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
        stamina = stats.maxStamina;
        regenRate = stats.regenRate;

        display.UpdateDisplay();
    }

    public void Regen()
    {
        stamina += regenRate * Time.deltaTime;
        display.UpdateDisplay();
    }

    public IEnumerator RegenStam()
    {
        isCoRunning = true;
        yield return new WaitForSeconds(4f);
        canRegen = true;
        isCoRunning = false;
    }

    public void CallRegenStam()
    {
        if (isCoRunning)
        {
            StopCoroutine(RegenStam());
            isCoRunning = false;
        }
        StartCoroutine(RegenStam());
    }
}
