using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public Transform camera;
    public Vector3 offset;

    public bool toCamera;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        target = transform.parent.gameObject.transform;

        if (toCamera)
        {
            //Vector3 targetPostition = new Vector3(camera.position.x, camera.position.y, camera.position.z);
            transform.LookAt(camera);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = target.position + offset;

            if (toCamera)
            {
                Vector3 targetPostition = new Vector3(camera.position.x, this.transform.position.y, camera.position.z);
                transform.LookAt(targetPostition);
            }
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
            }
}
