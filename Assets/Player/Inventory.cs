using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Inventory : MonoBehaviour
{
    #region Variables
    public List<Item> inv = new List<Item>();
    public static bool showInv;

    public Item currItem;

    public int money;

    public Vector2 scr = Vector2.zero;
    public Vector2 scrollPos = Vector2.zero;
    #endregion
    // Use this for initialization
    void Start()
    {
        //inv.Add(ItemData.CreateItem(102));
        //inv.Add(ItemData.CreateItem(200));
        //inv.Add(ItemData.CreateItem(201));
        //inv.Add(ItemData.CreateItem(301));
        //inv.Add(ItemData.CreateItem(300));
        //inv.Add(ItemData.CreateItem(400));
        //inv.Add(ItemData.CreateItem(404));
        inv.Add(ItemData.CreateItem(403));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Pause.paused)
        {
            ToggleInv();
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            Debug.ClearDeveloperConsole();
            showInv = false;
            Time.timeScale = 1;
            return false;
        }

        showInv = true;
        GetInv();
        Time.timeScale = 0;
        return true;
    }

    void GetInv()
    {
        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name + ": " + inv[i].Description);
        }
    }

    private void OnGUI()
    {
        if (!Pause.paused)
        {
            if (showInv)
            {
                if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
                {
                    scr.x = Screen.width / 16;
                    scr.y = Screen.height / 9;
                }

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                #region NoScrollInv
                if (inv.Count <= 35)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (GUI.Button(new Rect(0.5f*scr.x, 0.5f*scr.y + i*(0.5f *scr.y), 3*scr.x, 0.5f * scr.y), inv[i].Name))
                        {
                            currItem = inv[i];
                            Debug.Log(currItem.Name);
                        }
                    }
                }
                #endregion
                #region ScrollInv

                #endregion
            }
        }
    }
}
