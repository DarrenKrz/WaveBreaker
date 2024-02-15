using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBehaviour : MonoBehaviour
{
    public PlayerInfo player;
    public Image healthBar;
    public TMP_Text healthText;

    public void TakeDamage(float damage) {
        if ((player.currentHealth - damage) < 0) {
            player.currentHealth = 0;
        }
        else {
            player.currentHealth -= damage;
        }
        healthText.text = player.currentHealth.ToString();
        healthBar.fillAmount = player.currentHealth / 10f;
    }
    public void Heal(float healingAmount) {
        player.currentHealth += healingAmount;
        player.currentHealth = Mathf.Clamp(player.currentHealth, 0, 10);
        healthText.text = player.currentHealth.ToString();
        healthBar.fillAmount = player.currentHealth / 10f;
    }
}