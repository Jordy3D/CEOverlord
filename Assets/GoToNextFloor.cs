using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToNextFloor : MonoBehaviour
{
    public GameObject player;
    public PlayerSpawn playerSpawn;
    public CurrentLevelStats level;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawn = player.GetComponent<PlayerSpawn>();
        level = GameObject.Find("CurrentLevelManager").GetComponent<CurrentLevelStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            level.currentLevel += 1;
            Debug.Log("Going to " + level.currentLevel);
            if (SceneManager.GetActiveScene().name == "God")
            {
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, -2.1f);

                SceneManager.LoadScene("God");
            }
        }
    }
}