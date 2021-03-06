﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    #region Vars
    [SerializeField] public static float damage;
    public float fuck;

    public float health;
    public float maxHealth;

    public float moveSpeed;
    public float attackSpeed;
    public float attackRange;
    public float stamina;
    public float regenRate;
    public bool canRegen = true;
    public bool canMove = true;
    bool isCoRunning = false;

    PlayerStats stats;
    CharacterMovement movementStats;
    DisplayStats display;
    public GameObject dontDestroy;

    public GameObject endScreen;
    #endregion

    // Use this for initialization
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        movementStats = GetComponent<CharacterMovement>();
        display = GameObject.Find("GamePanel").GetComponent<DisplayStats>();
        endScreen = GameObject.Find("Continue");
        endScreen.SetActive(false);

        UpdateStats();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        fuck = damage;
        //check health and stamina values
        CheckStamina();
        CheckHealth();
        //update the display
        display.UpdateDisplay();
    }

    public void UpdateStats()
    {
        maxHealth = stats.health;
        moveSpeed = stats.moveSpeed;
        damage = stats.damage;
        attackSpeed = stats.attackSpeed;
        attackRange = stats.attackRange;
        stamina = stats.maxStamina;
        regenRate = stats.regenRate;
        //set stats in movement script
        movementStats.moveSpeed = moveSpeed;
        movementStats.regenRate = regenRate;

        display.UpdateDisplay();
    }


    #region Stamina Regen
    public void Regen()
    {
        stamina += regenRate * Time.deltaTime;

    }

    public IEnumerator RegenStam()
    {
        isCoRunning = true;
        yield return new WaitForSeconds(4f);
        canRegen = true;
        isCoRunning = false;
    }

    public void CallRegenStam()
    {
        if (isCoRunning)
        {
            StopCoroutine(RegenStam());
            isCoRunning = false;
        }
        StartCoroutine(RegenStam());
    }
    #endregion

    #region Health/Stamina Checks
    void CheckHealth()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health < 0)
        {
            health = 0;
        }

        if (health == 0)
        {
            Die();
        }
    }

    void CheckStamina()
    {
        if (canRegen)
        {
            Regen();
            if (stamina > 100)
            {
                stamina = 100;
            }
        }

        if (stamina < 0)
        {
            stamina = 0;
        }
    } 
    #endregion

    public void ChangeHealth(float value)
    {
        Debug.Log("Removing " + value + " health");
        health += value;
        CheckHealth();
    }

    public void EndGame()
    {
        Time.timeScale = 1;
        dontDestroy.GetComponent<PermanentObject>().enabled = false;
        Destroy(dontDestroy);
        SceneManager.LoadScene("God");
    }

    void Die()
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
    }

    public void FuckOff()
    {
        Application.Quit();
    }

}
