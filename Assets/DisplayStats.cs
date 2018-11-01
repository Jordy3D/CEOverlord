﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text healthText, moveSpeedText, damageText, attackSpeedText, attackRangeText;

    PlayerStats stats;
    // Use this for initialization
    void Start()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        moveSpeedText = GameObject.Find("MoveSpeedText").GetComponent<Text>();
        damageText = GameObject.Find("DamageText").GetComponent<Text>();
        attackSpeedText = GameObject.Find("AttackSpeedText").GetComponent<Text>();
        attackRangeText = GameObject.Find("AttackRangeText").GetComponent<Text>();

        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        UpdateDisplay();
    }

    // Update is called once per frame
    public void UpdateDisplay()
    {
        healthText.text = stats.health.ToString();
        moveSpeedText.text = stats.moveSpeed.ToString();
        damageText.text = stats.damage.ToString();
        attackSpeedText.text = stats.attackSpeed.ToString();
        attackRangeText.text = stats.attackRange.ToString();
    }
}