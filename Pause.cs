using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public TMP_Text pausedText;
    private bool paused;
    public GameObject restartGame;
    public GameObject mainMenu;
    public TMP_Text playAgain;
    void Update()
    {
        pauseScreen.SetActive(paused);
        restartGame.SetActive(paused);
        mainMenu.SetActive(paused);
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false) {
            PauseGame();
            pauseScreen.SetActive(paused);
            restartGame.SetActive(paused);
            mainMenu.SetActive(paused);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true) {
            ResumeGame();
            pauseScreen.SetActive(paused);
            restartGame.SetActive(paused);
            mainMenu.SetActive(paused);
        }

    }
    void PauseGame() {
        paused = true;
        Time.timeScale = 0f;
        playAgain.text = "Restart Game";
    }
    void ResumeGame() {
        paused = false;
        Time.timeScale = 1f;
        playAgain.text = "Play Again";
    }
}
