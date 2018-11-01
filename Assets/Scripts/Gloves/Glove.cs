using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Glove : MonoBehaviour
{


    #region Variables
    public float damage;
    public int comboLimit;
    public float range;
    public PlayerAttack player;
    #endregion
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Attack();
    
}
