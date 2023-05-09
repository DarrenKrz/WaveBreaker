using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    Dictionary<GameObject, int> itemPrices = new Dictionary<GameObject, int>();
    public GameObject HealthItem;
    public PlayerInfo player1;
    public PlayerInfo player2;    

    void Start() {
        itemPrices.Add(HealthItem, 5);
    }
    public void FillStore() {
        HealthItem.SetActive(true);
    }
    public void Update() {
        if (Input.GetKeyDown("z") & HealthItem.activeSelf == true) {
            ItemSoldToPlayer(HealthItem, player1);
        }
        if (Input.GetKeyDown("m") & HealthItem.activeSelf == true) {
            ItemSoldToPlayer(HealthItem, player2);
        }
    }
    public void ItemSoldToPlayer(GameObject item, PlayerInfo player) {
        if (player.rippleCount >= itemPrices[item]) {
            if (item.tag.ToString() == "HealthItem" & player.currentHealth == 10) {
                print("Already Full HP");
            }
            else {
                player.rippleCount -= itemPrices[item];
                player.RippleText.text = player.rippleCount.ToString();
                item.SetActive(false);
                player.ItemPurchasedFromStore(item, player);
            }
        }
        else {
            print("Not enough ripples");
        }
    }
}
