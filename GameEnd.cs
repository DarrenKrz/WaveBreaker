using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public HealthBehaviour P1health;
    public HealthBehaviour P2health;
    public bool gameOverFlag = false;
    public GameObject gameEndScreen;
    public GameObject P1WinsGameEndText;
    public GameObject P2WinsGameEndText;
    public GameObject playAgain;
    public GameObject mainMenu;
    void Update() {
        if (P1health.health == 0 | P2health.health == 0) {
            gameOverFlag = true;
            Time.timeScale = 0f;
            playAgain.SetActive(gameOverFlag);
            mainMenu.SetActive(gameOverFlag);
            gameEndScreen.SetActive(gameOverFlag);
            if (P1health.health == 0) {
                P2WinsGameEndText.SetActive(gameOverFlag);
            }
            else {
                P1WinsGameEndText.SetActive(gameOverFlag);
            }
        }
    }
}
