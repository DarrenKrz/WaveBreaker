using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCrash : MonoBehaviour
{
    int health = 10;
    public TMP_Text healthText;


    void OnCollisionEnter2D(Collision2D collision) {
        health--;
        healthText.text = health.ToString();
    }
}
