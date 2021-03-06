﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{

    public Transform spawn;
    public GameObject projectile;
    public float delay;
    public Behaviour state;
    public abstract void Attack();

}
