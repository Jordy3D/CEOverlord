using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {

    //position of the room with const y val
    public Vector3 roomPos;

    //int denoting room type. Use string later if we have a  bunch of rooms
    public int type;

    //bool denoting which doors need to be made
    public bool doorTop, doorBot, doorLeft, doorRight;

    

    //constructor to easily create rooms
    public Room(Vector3 _roomPos, int _type)
    {
        roomPos = _roomPos;
        type = _type;
    }
	
}
