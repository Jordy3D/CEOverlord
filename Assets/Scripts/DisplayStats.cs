using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text healthText, moveSpeedText, damageText, attackSpeedText, attackRangeText;
    public Slider staminaSlider;

    PlayerStats stats;
    PlayerManager player;

    void Awake()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        moveSpeedText = GameObject.Find("MoveSpeedText").GetComponent<Text>();
        damageText = GameObject.Find("DamageText").GetComponent<Text>();
        attackSpeedText = GameObject.Find("AttackSpeedText").GetComponent<Text>();
        attackRangeText = GameObject.Find("AttackRangeText").GetComponent<Text>();

        staminaSlider = GameObject.Find("StaminaBar").GetComponent<Slider>();

        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Use this for initialization
    void Start()
    {
        

        staminaSlider.maxValue = stats.maxStamina;

        UpdateDisplay();
    }

    // Update is called once per frame
    public void UpdateDisplay()
    {
        healthText.text = player.health + "/" + player.maxHealth;
        moveSpeedText.text = stats.moveSpeed.ToString();
        damageText.text = stats.damage.ToString();
        attackSpeedText.text = stats.attackSpeed.ToString();
        attackRangeText.text = stats.attackRange.ToString();

        staminaSlider.value = player.stamina;
    }
}
