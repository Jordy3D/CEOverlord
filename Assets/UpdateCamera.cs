using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCamera : MonoBehaviour
{
    public GameObject camera;
    public Transform cameraPoint;
    // Use this for initialization
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraPoint = gameObject.transform.GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camera.transform.position = cameraPoint.position;
        }
    }
}
