using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject shopScreen;
    public GameObject P1ReadyButton;
    public GameObject P2ReadyButton;
    public TMP_Text shopText;
    public bool P1Ready;
    public bool P2Ready;
    public OnGameLoad start;
    public bool inShop;
    public GameObject P1ReadyToggle;
    public GameObject P2ReadyToggle;
    void Start() {
        shopScreen.SetActive(false);
        P1ReadyButton.SetActive(false);
        P2ReadyButton.SetActive(false);
        P1ReadyToggle.SetActive(false);
        P2ReadyToggle.SetActive(false);
    }
    public void ShowShop() {
        inShop = true;
        shopScreen.SetActive(true);
        P1ReadyButton.SetActive(true);
        P2ReadyButton.SetActive(true);
        P1ReadyToggle.SetActive(true);
        P2ReadyToggle.SetActive(true);
    }
    public void SetP1Ready() {
        P1Ready = true;
        P1ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
        Ready();
    }
    public void SetP2Ready() {
        P2Ready = true;
        P2ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
        Ready();
    }
    public void Ready() {
        if (P1Ready & P2Ready) {
            start.StartGame();
            inShop = false;
            P1Ready = false;
            P2Ready = false;
            P1ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
            P2ReadyToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
            shopScreen.SetActive(false);
            P1ReadyButton.SetActive(false);
            P2ReadyButton.SetActive(false);
            P1ReadyToggle.SetActive(false);
            P2ReadyToggle.SetActive(false);
        }
    }
}