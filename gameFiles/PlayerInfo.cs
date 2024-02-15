using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public int rippleCount;
    public float currentHealth;
    public float maxHealth = 10;
    public List<GameObject> Inventory;
    public TMP_Text RippleText;
    public Item itemInfo;
    public float reflectCooldown;
    public TMP_Text playerCountdown;
    public bool coolDownActive;

    public void start() {
        currentHealth = maxHealth;
    }

    public void ItemPurchasedFromStore(GameObject item, PlayerInfo player) {
        itemInfo.Effect(item, player);
        if (item.tag.ToString() != "HealthItem") {
            Inventory.Add(item);
        }
    }
    public void gainRipple(int ripple) {
        rippleCount += ripple;
        RippleText.text = rippleCount.ToString();
    }
    public void startCooldown(float x) {
        reflectCooldown = x;
        coolDownActive = true;
    }
    void Update() {
        if (reflectCooldown > 0) {
            reflectCooldown -= Time.deltaTime;
        }
        else {
            reflectCooldown = 0;
            coolDownActive = false;
        }
        playerCountdown.text = reflectCooldown.ToString("0.0");
    }
}
