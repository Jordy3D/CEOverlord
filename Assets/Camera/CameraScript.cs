using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float cameraDistanceOffsetX = 5f; //Distance from the player along the X axis
    public float cameraDistanceOffsetZ = 5f; //Distance from the player along the X axis

    public float cameraHeightOffset = 1.5f; //Height above the player
    private Camera mainCamera; 
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>(); //Puts the Camera component into the mainCamera variable
        player = GameObject.FindGameObjectWithTag("Player"); //Puts the GameObject named Player in the player variable

        Vector3 playerTransform = player.transform.transform.position; //Sets playerTransform to the transform position
        Vector3 cameraTransform = mainCamera.transform.transform.position; //Sets playerTransform to the transform position

        mainCamera.transform.position = new Vector3(playerTransform.x - cameraDistanceOffsetX, playerTransform.y + cameraHeightOffset, playerTransform.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTransform = player.transform.transform.position; //Sets playerTransform to the transform position
        Vector3 cameraTransform = mainCamera.transform.transform.position; //Sets playerTransform to the transform position

        //mainCamera.transform.position = new Vector3(playerTransform.x - cameraDistanceOffset, playerTransform.y + cameraHeightOffset, cameraTransform.z); //Sets mainCamera's position to the player's, taking into account the offsets

        mainCamera.transform.position = new Vector3(playerTransform.x - cameraDistanceOffsetX, playerTransform.y + cameraHeightOffset, playerTransform.z - cameraDistanceOffsetZ); //Sets mainCamera's position to the player's, taking into account the offsets
        //transform.LookAt(playerTransform); //Makes the camera look at the player
    }
}
