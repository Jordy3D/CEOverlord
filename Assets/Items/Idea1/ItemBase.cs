using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CEOverlord.Items
{
    public abstract class ItemBase : MonoBehaviour
    {
        public float health;
        public float moveSpeed;
        public float damage;
        public float attackSpeed;
        public float attackRange;

        public virtual void SetDefaults()
        {
            health = 0;
            moveSpeed = 0;
            damage = 0;
            attackSpeed = 0;
            attackRange = 0;
        }
    }

    
}
