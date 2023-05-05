using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopScreen;
    public GameObject P1ReadyButton;
    public GameObject P2ReadyButton;
    public bool P1Ready;
    public bool P2Ready;
    public OnGameLoad start;
    public bool inShop;
    void Start() {
        shopScreen.SetActive(false);
        P1ReadyButton.SetActive(false);
        P2ReadyButton.SetActive(false);
    }
    public void ShowShop() {
        inShop = true;
        shopScreen.SetActive(true);
        P1ReadyButton.SetActive(true);
        P2ReadyButton.SetActive(true);
    }
    public void SetP1Ready() {
        P1Ready = true;
        Ready();
    }
    public void SetP2Ready() {
        P2Ready = true;
        Ready();
    }
    public void Ready() {
        if (P1Ready & P2Ready) {
            start.StartGame();
            inShop = false;
            shopScreen.SetActive(false);
            P1ReadyButton.SetActive(false);
            P2ReadyButton.SetActive(false);
        }
    }
}
