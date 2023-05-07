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
}
