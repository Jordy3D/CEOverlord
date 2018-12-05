using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody playerRB;
    //references the rigidbody for the player

   
    public float moveSpeed;
    
    public float regenRate;
    public float dashTime = 0f;
    public bool isInputAllowed = true;

    public PlayerStats stats;
    public Vector3 lookDir;
    PlayerManager playerManager;
    
    public bool isDashing = false;

    float forcedFixTime = 0f;

    public void Start()
    {
        //gets and attaches the rigidbody
        playerRB = GetComponent<Rigidbody>();
        //constains the x rotation, z rotation and y position
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        //main camera is equal to the camera in the scene
        playerManager = GetComponent<PlayerManager>();
        stats = GetComponent<PlayerStats>();
        
        //UpdateStats();
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

        if (playerManager.canMove == false && isDashing == false)
        {
            float forceFixMax = 4f;
            if (forcedFixTime <= forceFixMax)
            {
                Debug.Log("Forcing a fix: " + forcedFixTime);
                forcedFixTime += Time.deltaTime;
                if (forcedFixTime >= forceFixMax)
                {
                    playerManager.canMove = true;
                    forcedFixTime = 0;
                }
            }
        }

        GetLookDir();
        transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
    }
    // Update is called once per frame
    public void FixedUpdate()
    {

        if (playerManager.canMove)
        {
            Vector3 force = GetMoveDir();

            if (Input.GetKeyDown(KeyCode.LeftShift) && playerManager.stamina > 0 && !isDashing)
            {

                Dash(force);

            }

           

            // Make bool called:
            if (playerManager.canMove)
                playerRB.velocity = force;

            /*
            if (playerRB.velocity != Vector3.zero && (Input.GetAxis("VerLook") == 0 || Input.GetAxis("HorLook") == 0))
            {
                playerRB.rotation = Quaternion.LookRotation(playerRB.velocity);
            } 
            */
        }
        
    }

    void OnTriggerStay(Collider enemy)
    {
        //if the players collider touches the enemy's collider and isShadow = true
        if (enemy.gameObject.tag == "Enemy")
        {
            Debug.Log("Entered wrong house fool");
        }
    }

   

    

    //called from playerManager to update needed values here
    public void UpdateStats()
    {
        moveSpeed = stats.moveSpeed;
        regenRate = stats.regenRate;
    }

    public IEnumerator EnableInput(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerManager.canMove = true;
    }

    public void Dash(Vector3 force)
    {
        playerRB.velocity = Vector3.zero;
        playerManager.canMove = false;
        playerRB.AddForce(force.normalized * 20f, ForceMode.Impulse);
        StartCoroutine(EnableInput(0.1f));
        playerManager.stamina -= 20f;
        if (playerManager.stamina < 0)
        {
            playerManager.stamina = 0;
            Debug.Log("Out of stamina");
        }
        playerManager.canRegen = false;



        playerManager.CallRegenStam();
    }

    public Vector3 GetMoveDir()
    {
        float inputH = Input.GetAxis("HorMovement") * moveSpeed;
        float inputV = Input.GetAxis("VerMovement") * moveSpeed;


        Vector3 moveDir = new Vector3(inputH, 0f, inputV) * moveSpeed;
        Vector3 force = new Vector3(moveDir.x, playerRB.velocity.y, moveDir.z);
        return force;
    }

    public void GetLookDir()
    {
        float x = Input.GetAxis("HorLook");
        float z = Input.GetAxis("VerLook");

        if (x > 0)
        {
            x = 1;
        }
        if (x < 0)
        {
            x = -1;
        }
        //Run this zero check after applying X direction
        if ((x < 1 && x > 0) || (x > -1 && x < 0))
        {
            x = 0;
        }
        ///////////////////////////
        if (z > 0)
        {
            z = 1;
        }
        if (z < 0)
        {
            z = -1;
        }
        //Run this zero check after applying Z direction
        if ((z < 1 && z > 0) || (z > -1 && z < 0))
        {
            z = 0;
        }

        lookDir = new Vector3(x, 0, z).normalized;
       // Vector3 potentialDir = new Vector3(x, 0, z).normalized;
       if(lookDir == Vector3.zero)
        {
            lookDir.z = -1f;
        }

    }
}
