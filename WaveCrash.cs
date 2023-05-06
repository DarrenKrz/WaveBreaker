using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCrash : MonoBehaviour
{
    public HealthBehaviour healthManager;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Renderer>().material.color.ToString() == "RGBA(0.467, 0.584, 0.792, 1.000)") {
            healthManager.TakeDamage(1);
        }
        else if (collision.gameObject.GetComponent<Renderer>().material.color.ToString() == "RGBA(0.651, 0.204, 0.090, 1.000)") {
            healthManager.TakeDamage(2);
        }
        else if (collision.gameObject.GetComponent<Renderer>().material.color.ToString() == "RGBA(1.000, 0.000, 0.753, 1.000)") {
            healthManager.TakeDamage(3);
        }
    }
}
