using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public TMP_Text P1Health;
    public TMP_Text P2Health;
    void Update() {
        if (Convert.ToInt32(P1Health.text) <= 0) {
            Debug.Log("GameOver, Player2 wins");
        }
        else if (Convert.ToInt32(P2Health.text) <= 0) {
            Debug.Log("GameOver, Player1 wins");
        }
    }
}
