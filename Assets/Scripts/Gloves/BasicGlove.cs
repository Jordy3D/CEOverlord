using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGlove : Glove {

    private void Start()
    {
        comboLimit = 3;
        player.comboLimit = comboLimit;
    }

    public override void Attack()
    {
        Debug.Log("This is basic glove");
    }
}
