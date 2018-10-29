using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : MonoBehaviour
{

    public bool up, down, left, right;

    public int type;

    //all doors disabled by default
    public GameObject doorUp, doorDown, doorLeft, doorRight;

    private void Start()
    {
        doorDown.SetActive(false);
        doorUp.SetActive(false);
        doorLeft.SetActive(false);
        doorRight.SetActive(false);
        SetDoor();
    }

    public void SetDoor()
    {
        if (up)
        {
            doorUp.SetActive(true);
        }
        if (down)
        {
            doorDown.SetActive(true);
        }
        if (left)
        {
            doorLeft.SetActive(true);
        }
        if (right)
        {
            doorRight.SetActive(true);
        }

    }
}
