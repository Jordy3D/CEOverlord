using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelStats : MonoBehaviour
{
    public int currentLevel;

    public Text currentFloorText;
    // Use this for initialization
    void Start()
    {
        currentFloorText = GameObject.Find("CurrentFloorText").GetComponent<Text>();

        UpdateDisplay();
    }
    // Update is called once per frame
    void Update()
    {
        if (currentFloorText.text != "Ground")
        {
            if (!(currentFloorText.text.Contains(currentLevel.ToString())))
            {
                UpdateDisplay();
            }
        }
        if (currentFloorText.text == "Ground" && currentLevel != 0)
        {
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        Debug.Log("Your display should read " + currentLevel);
        if (currentLevel == 0)
        {
            currentFloorText.text = "Ground";
        }
        else if (currentLevel > 0 && currentLevel <= 5)
        {
            currentFloorText.text = "Floor  " + currentLevel;
        }
        else if (currentLevel > 5 && currentLevel <= 10)
        {
            currentFloorText.text = "F̝̘̳̖̲̉̓l̻̗͊͐̈̊ͯ̋ͣȏ̺̭̮̠̑̉o̥̯̟̘͓̗ͦ̊̑̆ͦṟ͔̣̣̰ͣ͋̎̅̏  " + currentLevel;
        }
        else 
        {
            currentFloorText.text = "F̹͋̅ͪͮ͢͟ḽ̇̃̋̈́̕ö̧̮̣̼͎̘ͭ̊ͩ͒͋̒̅́o͊̂̊ͯ̆̂͊͏̣̞̼͕͚̝͢r̤̮̐ͥ͂͂͌͆̌͞  " + currentLevel;
        }
    }
}