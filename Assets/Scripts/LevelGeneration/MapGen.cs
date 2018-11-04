using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapGen : MonoBehaviour
{

    public int tries = 0;

    //how big is the world? using room lengths as units

    Vector3 mapSizeTotal;

    //2d array to hold rooms
    public Room[,] rooms;

    //list of positions that have been taken so no double ups occur
    public List<Vector3> takenPositions = new List<Vector3>();

    //list of actual rooms with RoomSelector
    Dictionary<Vector3, RoomSelector> realRooms = new Dictionary<Vector3, RoomSelector>();
    List<RoomSelector> realRoomsList = new List<RoomSelector>();

    //paramenters for rooms and 'grid' size
    int gridSizeX, gridSizeZ;

    public int numRooms = 20;

    //the room we will spawn
    public GameObject[] roomTypes;

    //has the bossRoom spawned
    [HideInInspector]public bool isBossRoom = false;

    public int treasureRoomCount = 0;

    //Player reference to activate player when map is generated
    public GameObject player;
    public PlayerSpawn playerSpawn;

    //bool to ensure map generation has been successful
    public bool isGenerated;

    float timeToGenerate = 0f;

    void Awake()
    {
        if (numRooms<3)
        {
            numRooms = 3;
        }

        mapSizeTotal = new Vector3(numRooms *2, 0, numRooms*2);

        timeToGenerate = 0f;

        //check to see if numRooms will exceed size of grid
        if (numRooms >= (mapSizeTotal.x * 2) * (mapSizeTotal.z * 2))
        {
            numRooms = Mathf.RoundToInt((mapSizeTotal.x * 2) * (mapSizeTotal.z * 2));
        }
        //set grid sizes to mapSizeTotals x and z values
        gridSizeX = Mathf.RoundToInt(mapSizeTotal.x);
        gridSizeZ = Mathf.RoundToInt(mapSizeTotal.z);
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawn = player.GetComponent<PlayerSpawn>();
        SetUpMap();
        CreateMap();
        FindTeleportPoint();
       //Debug.Log(rooms.Length);
        Debug.Log(Time.realtimeSinceStartup);
    }

    private void Start()
    {
        //spawn the player to start room
        playerSpawn.SpawnPlayer();
    }

    public void CreateRooms()
    {
        //set up for method
        rooms = new Room[gridSizeX * 2, gridSizeZ * 2];
        //PLACE STARTING ROOM NEAR CENTRE OF GRID TO ENSURE MAX SPREAD. room type 1 for starting room
        rooms[gridSizeX, gridSizeZ] = new Room(Vector3.zero, 0);
        //add the starting room to list of taken room positions
        takenPositions.Insert(0, Vector3.zero);
        //use position to make checks later
        Vector3 checkPos = Vector3.zero;

        //numbers that ensure more random spread as time progresses
        float randomCompare = 0.2f, randCompStart = 0.2f, randCompFin = 0.01f;
        //add in rooms
        //for loop runs once for each room we wish to create
        for (int i = 0; i < numRooms - 1; i++)
        {
            //add comment after figure out what this does
            float randomVal = ((float)i / ((float)numRooms - 1));
            randomCompare = Mathf.Lerp(randCompStart, randCompFin, randomVal);
            //Debug.Log(randomCompare);

            //grab a new position using method
            checkPos = NewPosition();

            //test new position. If statement here uses values above to have dungeon branch less as it creates more rooms


            if (NumberOfAdjacentRooms(checkPos, takenPositions) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;

                while (NumberOfAdjacentRooms(checkPos, takenPositions) > 1 && iterations < 100)
                {
                    //find new positions where only 1 neighbour exits
                    checkPos = SelectiveNewPosition();
                    iterations++;

                }
                if (iterations >= 50)
                {
                    Debug.Log("Couldnt create with fewer neighbours than :" + NumberOfAdjacentRooms(checkPos, takenPositions));
                }

            }


            //finalize position
            //create a new room at check pos, adding it to the 2d array with offset 
            int roomType = Mathf.RoundToInt(Random.Range(1f, 2f));
            rooms[(int)checkPos.x + gridSizeX, (int)checkPos.z + gridSizeZ] = new Room(checkPos, roomType);
            takenPositions.Insert(0, checkPos);
        }


    }

    public Vector3 NewPosition()
    {
        int x = 0, z = 0;
        Vector3 checkingPos = Vector3.zero;
        while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || z >= gridSizeZ || z < -gridSizeZ)
        {
            //grab a taken position at random to move up,down,left or right from 
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
            x = (int)takenPositions[index].x;
            z = (int)takenPositions[index].z;
            bool ZAxis = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (ZAxis)
            {
                if (positive)
                {
                    z += 1;
                }
                else
                {
                    z -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector3(x, 0f, z);

        }
        return checkingPos;
    }

    //gets the number of rooms next to a given pos
    public int NumberOfAdjacentRooms(Vector3 pos, List<Vector3> usedPositions)
    {

        int returnedVal = 0;
        if (usedPositions.Contains(pos + Vector3.right))
        {
            returnedVal++;
        }
        if (usedPositions.Contains(pos + Vector3.left))
        {
            returnedVal++;
        }
        if (usedPositions.Contains(pos + Vector3.forward))
        {
            returnedVal++;
        }
        if (usedPositions.Contains(pos + Vector3.back))
        {
            returnedVal++;
        }
        return returnedVal;

    }

    //getting room that only has 1 neighbour. adds to branching effect when required
    public Vector3 SelectiveNewPosition()
    {
        int index = 0, inc = 0;
        int x = 0, z = 0;
        Vector3 checkingPos = Vector3.zero;
        while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || z >= gridSizeZ || z < -gridSizeZ)
        {
            inc = 0;
            //while taken pos at index has more than 1 neighbour and inc < 100
            while (NumberOfAdjacentRooms(takenPositions[index], takenPositions) > 1 && inc < 100)
            {
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            }
            x = (int)takenPositions[index].x;
            z = (int)takenPositions[index].z;
            bool ZAxis = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (ZAxis)
            {
                if (positive)
                {
                    z += 1;
                }
                else
                {
                    z -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector3(x, 0, z);
        }
        return checkingPos;
    }

    void SetRoomDoors()
    {
        //loop through the grid
        for (int x = 0; x < gridSizeX * 2; x++)
        {
            for (int z = 0; z < gridSizeZ * 2; z++)
            {
                if (rooms[x, z] == null)
                {
                    continue;
                }
                Vector3 gridPos = new Vector3(x, 0, z);


                if (z - 1 < 0)//check above
                {
                    rooms[x, z].doorBot = false;
                }
                else
                {
                    rooms[x, z].doorBot = (rooms[x, z - 1] != null);
                }

                if (z + 1 >= gridSizeZ * 2)//check bellow
                {
                    rooms[x, z].doorTop = false;
                }
                else
                {
                    rooms[x, z].doorTop = (rooms[x, z + 1] != null);
                }

                if (x - 1 < 0)//check left
                {
                    rooms[x, z].doorLeft = false;
                }
                else
                {
                    rooms[x, z].doorLeft = (rooms[x - 1, z] != null);
                }

                if (x + 1 >= gridSizeX * 2)//check right
                {
                    rooms[x, z].doorRight = false;
                }
                else
                {
                    rooms[x, z].doorRight = (rooms[x + 1, z] != null);
                }
            }
        }
    }

    void CreateMap()
    {
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            Vector3 roomPos = room.roomPos;
            //needs to be room dimensions (estimates)
            roomPos.x *= 26;
            roomPos.z *= 16;

            RoomSelector roomCurrent = Object.Instantiate(roomTypes[room.type], roomPos, Quaternion.identity).GetComponent<RoomSelector>();
            roomCurrent.gridPos = room.roomPos;
            roomCurrent.up = room.doorTop;
            roomCurrent.down = room.doorBot;
            roomCurrent.left = room.doorLeft;
            roomCurrent.right = room.doorRight;
            roomCurrent.type = room.type;
            realRooms.Add(roomCurrent.gridPos, roomCurrent);
            realRoomsList.Add(roomCurrent);

        }
    }

    void FindBossRoom()
    {

        isBossRoom = false;

        Room bossRoom = null;
        float maxDist = 0f;

        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            Vector3 roomPos = room.roomPos;
            float dist = Vector3.Distance(Vector3.zero, roomPos);
            if (dist > maxDist)
            {
                if (!(NumberOfAdjacentRooms(roomPos, takenPositions) > 1) && isBossRoom == false)
                {
                    maxDist = dist;
                    bossRoom = room;
                }
            }


        }

        if (bossRoom != null)
        {
            bossRoom.type = 4;
            isBossRoom = true;
            
        }

        //check if a boss room was made
        if (isBossRoom == false)
        {
            isGenerated = false;
        }
    }

    void CreateMiscRooms()
    {
        bool madeTreasureRoom = false;
        //create a list of rooms that fit criteria incase we do not randomly generate one
        List<Room> possibleRooms = new List<Room>();
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            Vector3 pos = room.roomPos;
            if (NumberOfAdjacentRooms(pos, takenPositions) == 1)
            {
                //if not boss room or starting room
                if (room.type != 4 && room.type != 0)
                {
                    possibleRooms.Add(room);
                    bool makeRoom = (Random.value > 0.7f);

                    //make treasure rooms based on total rooms
                    if (makeRoom)
                    {
                        if (numRooms < 6 && treasureRoomCount < 1)
                        {
                            room.type = 3;
                            treasureRoomCount++;
                            madeTreasureRoom = true;
                        }
                        else if (numRooms >= 6 && treasureRoomCount < 2)
                        {
                            room.type = 3;
                            treasureRoomCount++;
                            madeTreasureRoom = true;
                        }
                    }

                }
            }
        }

        if (treasureRoomCount == 0)
        {
            if (possibleRooms.Count != 0)
            {
                int listIndex = Mathf.RoundToInt(Random.Range(0, (possibleRooms.Count - 1)));
                possibleRooms[listIndex].type = 3;
                Debug.Log("Manual Treasure Room");
                madeTreasureRoom = true;
            }
        }

        //check to see if a treasure room was made
        if (madeTreasureRoom == false)
        {
            //make it loop again
            isGenerated = false;
        }
    }


    //finds teleport point of room using int to represent direction
    public void FindTeleportPoint()
    {
        foreach (RoomSelector room in realRoomsList)
        {
            if (room.up)
            {
                //check if there is in fact a room above
                if (realRooms.ContainsKey(room.gridPos + Vector3.forward))
                {
                    RoomSelector upRoom = realRooms[room.gridPos + Vector3.forward];
                    DoorTeleport doorTP = room.doorUp.GetComponent<DoorTeleport>();
                    //set doors teleport position to the teleport point opposite in next room
                    doorTP.destination = upRoom.doorTPD.transform;
                }
            }

            if (room.down)
            {
                if (realRooms.ContainsKey(room.gridPos + Vector3.back))
                {
                    RoomSelector downRoom = realRooms[room.gridPos + Vector3.back];
                    DoorTeleport doorTP = room.doorDown.GetComponent<DoorTeleport>();
                    //set doors teleport position to the teleport point opposite in next room
                    doorTP.destination = downRoom.doorTPU.transform;
                }
            }

            if (room.left)
            {
                if (realRooms.ContainsKey(room.gridPos + Vector3.left))
                {
                    RoomSelector leftRoom = realRooms[room.gridPos + Vector3.left];
                    DoorTeleport doorTP = room.doorLeft.GetComponent<DoorTeleport>();
                    //set doors teleport position to the teleport point opposite in next room
                    doorTP.destination = leftRoom.doorTPR.transform;
                }
            }

            if (room.right)
            {
                if (realRooms.ContainsKey(room.gridPos + Vector3.right))
                {
                    RoomSelector rightRoom = realRooms[room.gridPos + Vector3.right];
                    DoorTeleport doorTP = room.doorRight.GetComponent<DoorTeleport>();
                    //set doors teleport position to the teleport point opposite in next room
                    doorTP.destination = rightRoom.doorTPL.transform;
                }
            }
        }
    }

    public void SetUpMap()
    {
        while (isGenerated == false)
        {
            //redo generation
            takenPositions = new List<Vector3>();
            isGenerated = true;
            CreateRooms();
            SetRoomDoors();
            FindBossRoom();
            CreateMiscRooms();
            tries++;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
