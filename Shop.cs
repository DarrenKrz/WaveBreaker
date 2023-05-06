using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject shopScreen;
    public GameObject P1ReadyButton;
    public GameObject P2ReadyButton;    
    public OnGameLoad start;
    public GameObject P1ReadyToggle;
    public GameObject P2ReadyToggle;
    public TMP_Text shopText;
    public Pause checkPause;
    public bool P1Ready;
    public bool P2Ready;
    public bool inShop = false;

    public void Update() {
        shopScreen.SetActive(inShop);
        P1ReadyButton.SetActive(inShop);
        P2ReadyButton.SetActive(inShop);
        P1ReadyToggle.SetActive(inShop);
        P2ReadyToggle.SetActive(inShop);
    }
    public void ShowShop() {
        inShop = true;
        Update();
    }
    public void SetP1Ready() {
        if (checkPause.paused == false) {
            P1Ready = true;
            P1ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
            Ready();
        }
    }
    public void SetP2Ready() {
        if (checkPause.paused == false) {
            P2Ready = true;
            P2ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
            Ready();
        }
    }
    public void Ready() {
        if (P1Ready & P2Ready) {
            start.StartGame();
            inShop = false;
            P1Ready = false;
            P2Ready = false;
            P1ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
            P2ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }
    }
}