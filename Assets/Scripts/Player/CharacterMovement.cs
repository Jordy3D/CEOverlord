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
    PlayerManager playerManager;

    

    public bool isDashing = false;
    
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
    }
    // Update is called once per frame
    public void FixedUpdate()
    {

        if (playerManager.canMove)
        {

            float inputH = Input.GetAxis("Horizontal") * moveSpeed;
            float inputV = Input.GetAxis("Vertical") * moveSpeed;


            Vector3 moveDir = new Vector3(inputH, 0f, inputV) * moveSpeed;
            Vector3 force = new Vector3(moveDir.x, playerRB.velocity.y, moveDir.z);

            //if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0)
            //{
            //    playerRB.AddForce(force * 10f, ForceMode.Impulse);

            //    Vector3 newPosition = force * 10f;
            //    // Use new position to lerp

            if (Input.GetKeyDown(KeyCode.LeftShift) && playerManager.stamina > 0 && !isDashing)
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


                // Coroutine to set "isInputAllowed" to false
                // Sets bool back to true after a few milliseconds

                //isDashing = true;
            }

            /*
            if (isDashing)
            {
                force = force * 2f;
                dashTime += Time.deltaTime; 
            }
            */

            // Make bool called:
            if (isInputAllowed)
                playerRB.velocity = force;

            if (playerRB.velocity != Vector3.zero)
            {
                playerRB.rotation = Quaternion.LookRotation(playerRB.velocity);
            } 
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
}
