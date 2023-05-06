using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public TMP_Text pausedText;
    public bool paused;
    public bool showWaveBreakFlag;
    public GameObject restartGame;
    public GameObject mainMenu;
    public TMP_Text playAgain;
    public GameObject countDown;
    public GameObject waveBreakText;
    public GameEnd checkGameOver;
    public Shop shop;
    void Update() {
        if (checkGameOver.gameOverFlag == false) {
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
    }
    void PauseGame() {
        paused = true;
        if (waveBreakText.activeSelf) { // If paused while wavebreak text on screen, store the fact it was on screen and then hide it
            showWaveBreakFlag = true;
            waveBreakText.SetActive(false);
        }
        countDown.SetActive(false);
        Time.timeScale = 0f;
        playAgain.text = "Restart Game";
    }
    void ResumeGame() {
        paused = false;
        if (showWaveBreakFlag) { // Put wavebreak text back on screen if needed
            waveBreakText.SetActive(true);
        }
        countDown.SetActive(true);
        Time.timeScale = 1f;
        playAgain.text = "Play Again";
    }
}