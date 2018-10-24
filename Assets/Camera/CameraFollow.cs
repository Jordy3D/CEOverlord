using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    //position, rotation and scale of the target object
    public Vector3 offset;
    //x,y,z coordinates

    void Start ()
    {
        //sets itself to be the parent to the target
        transform.SetParent(target);
        //gets the position, rotation and scale of the player
        target = GameObject.Find("Controller").GetComponent<Transform>();
        //offsets itself from the transforms position - the targets position
        offset = transform.position - target.position;
	}
	

	void Update ()
    {
        //the position, scale and rotationn is equal to the targets position, scale and rotation + the offset
        transform.position = target.position + offset;

    }
}
