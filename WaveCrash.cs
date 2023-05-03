using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCrash : MonoBehaviour
{
    int health = 10;

    void OnCollisionEnter2D(Collision2D collision) {
        health--;
        Debug.Log("collided with " + this.ToString() + ", health = " + health);
    }
}
