using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CEOverlord.Items
{
    public class Item1 : ItemBase
    {
        public override void SetDefaults()
        {
            health = 1;
            moveSpeed = 0;
            damage = 2;
            attackSpeed = 0;
            attackRange = 0;
        }
    }
}
