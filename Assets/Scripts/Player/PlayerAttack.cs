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
    public bool isCombo, isCooldown, canCombo = true;
    public float coolDownLimit, comboTimeLimit;
    PlayerManager playerManager;

    public Glove thingGloves;
    public GameObject hitbox;
    IEnumerator instance;
    
    #endregion
    // Use this for initialization
    void Start()
    {
        playerGlove = transform.GetChild(0).GetComponent<Glove>();
        playerManager = GetComponent<PlayerManager>();
        thingGloves = null;
    }

    // Update is called once per frame

        //adjust later to only allow for hits past certain points in animation
    void Update()
    {
        /*if (isCoolDown)
        {
            time += Time.deltaTime;
            if(time >= coolDownLimit)
            {
                isCoolDown = false;
                time = 0;
                Debug.Log("Cool down finished");
            }
        }
        */
        if (isCombo)
        {
            time += Time.deltaTime;
            if(time >= comboTimeLimit)
            {
                isCombo = false;
                comboPos = 0;
                Debug.Log("Combo Dropped");
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(comboPos < comboLimit && canCombo && playerManager.stamina != 0)
            {
                if (comboPos == 0)
                {
                    isCombo = true;
                    time = 0;
                    Debug.Log("Combo started");
                }

                playerGlove.Attack();
                comboPos++;
                playerManager.stamina -= 5f;
                playerManager.canRegen = false;
                playerManager.CallRegenStam();
                
                if(comboPos == comboLimit)
                {
                    isCombo = false;

                    instance = CoolDown(coolDownLimit);
                    CallCoolDown(instance);
                    time = 0;
                    comboPos = 0;
                    Debug.Log("Combo Finished");
                } else
                {
                    time = 0;
                }
            }
        }
    }

    IEnumerator CoolDown(float coolDown)
    {
        isCooldown = true;
        yield return new WaitForSeconds(coolDown);
        canCombo = true;
        isCooldown = false;
        Debug.Log("CoolDown Finished");
    }

    void CallCoolDown(IEnumerator instance)
    {
        if (isCooldown)
        {
            StopCoroutine(instance);
            isCooldown = false;
        }
        StartCoroutine(instance);
    }
}
