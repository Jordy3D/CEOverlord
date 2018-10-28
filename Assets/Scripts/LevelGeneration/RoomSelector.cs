using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : MonoBehaviour {

    public bool up, down, left, right;

    public int type;

    public GameObject wallUp, wallDown, wallLeft, wallRight;

    private void Start()
    {
        SetDoor();
    }

    public void SetDoor()
    {
        if (up)
        {
            wallUp.SetActive(false);
        }
        if (down)
        {
            wallDown.SetActive(false);
        }
        if (left)
        {
            wallLeft.SetActive(false);
        }
        if (right)
        {
            wallRight.SetActive(false);
        }
        
    }
}
