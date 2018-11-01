using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadGlove : Glove {

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        comboLimit = 2;
        player.comboLimit = comboLimit;
    }

    public override void Attack()
    {
        Debug.Log("This is lead glove");
    }
}
