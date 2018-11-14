using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapUpdate : MonoBehaviour
{
    GameObject mommy;
    GameObject miniMapPlane;

    // Use this for initialization
    void Start()
    {
        mommy = this.gameObject;

        miniMapPlane = mommy.transform.Find("MiniMapPlane").gameObject;
        miniMapPlane.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            miniMapPlane.SetActive(true);
        }
    }
}
