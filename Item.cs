using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int price = 5;
    public HealthBehaviour healPlayer1;
    public HealthBehaviour healPlayer2;
    public void Effect(GameObject item, PlayerInfo player) {
        if (player.tag.ToString() == "Player1") {
            healPlayer1.Heal(1);
        }
        if (player.tag.ToString() == "Player2") {
            healPlayer2.Heal(1);
        }
    }
}
