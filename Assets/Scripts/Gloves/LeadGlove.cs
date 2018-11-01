using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadGlove : Glove {

    private void Start()
    {
        comboLimit = 2;
        player.comboLimit = comboLimit;
    }

    public override void Attack()
    {
        Debug.Log("This is lead glove");
    }
}
