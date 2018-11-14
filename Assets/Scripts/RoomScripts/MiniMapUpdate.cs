using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapUpdate : MonoBehaviour
{
    GameObject mommy;
    GameObject miniMapPlane;

    GameObject tieIcon;

    private void Awake()
    {
        tieIcon = GameObject.Find("Tie");

        mommy = this.gameObject;

        miniMapPlane = mommy.transform.Find("MiniMapPlane").gameObject;
    }
    // Use this for initialization
    void Start()
    {
        miniMapPlane.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 newPos = new Vector3(miniMapPlane.transform.position.x, miniMapPlane.transform.position.y + 1f, miniMapPlane.transform.position.z);
            tieIcon.transform.position = newPos;
            miniMapPlane.SetActive(true);
        }
    }
}
