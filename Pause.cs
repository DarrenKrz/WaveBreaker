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
    public TMP_Text countDown;
    public TMP_Text waveBreakText;
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
        countDown.faceColor = new Color32(112,113,255,0);
        waveBreakText.faceColor = new Color32(112,113,255,0);
        paused = true;
        Time.timeScale = 0f;
        playAgain.text = "Restart Game";
    }
    void ResumeGame() {
        countDown.faceColor = new Color32(112,113,255,255);
        waveBreakText.faceColor = new Color32(112,113,255,0);
        paused = false;
        Time.timeScale = 1f;
        playAgain.text = "Play Again";
    }
}
