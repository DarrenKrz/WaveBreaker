using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public TMP_Text P1Health;
    public TMP_Text P2Health;
    private bool gameOverFlag = false;
    public GameObject gameEndScreen;
    public GameObject P1WinsGameEndText;
    public GameObject P2WinsGameEndText;
    public GameObject playAgain;
    public GameObject mainMenu;
    void Update() {
        gameEndScreen.SetActive(gameOverFlag);
        playAgain.SetActive(gameOverFlag);
        mainMenu.SetActive(gameOverFlag);
        P1WinsGameEndText.SetActive(false);
        P2WinsGameEndText.SetActive(false);
        if (Convert.ToInt32(P1Health.text) <= 0) {
            gameOverFlag = true;
            Time.timeScale = 0f;
            P2WinsGameEndText.SetActive(gameOverFlag);

        }
        else if (Convert.ToInt32(P2Health.text) <= 0) {
            gameOverFlag = true;
            Time.timeScale = 0f;
            P1WinsGameEndText.SetActive(gameOverFlag);
        }
    }
}
