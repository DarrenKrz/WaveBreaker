using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBehaviour : MonoBehaviour
{
    public float health = 10;
    public Image healthBar;
    public TMP_Text healthText;

    public void TakeDamage(float damage) {
        if ((health - damage) < 0) {
            health = 0;
        }
        else {
            health -= damage;
        }
        healthText.text = health.ToString();
        healthBar.fillAmount = health / 10f;
    }
    public void Heal(float healingAmount) {
        health += healingAmount;
        health = Mathf.Clamp(health, 0, 10);
        healthBar.fillAmount = health / 10f;
    }
}