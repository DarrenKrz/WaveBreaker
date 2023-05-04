using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameLoad : MonoBehaviour
{
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        StartGame();
    }
    void StartGame() {
        
    }
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
