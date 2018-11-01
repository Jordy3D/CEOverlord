using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Vars
    public Glove playerGlove;
    public int comboLimit;
    public float time = 0;
    //where we are in the combo
    public int comboPos = 0;
    public bool isCombo;

    public Glove thingGloves;
    
    #endregion
    // Use this for initialization
    void Start()
    {
        playerGlove = transform.GetChild(0).GetComponent<Glove>();

        thingGloves = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCombo)
        {
            time += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
        }
    }
}
