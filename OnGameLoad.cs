using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnGameLoad : MonoBehaviour
{
    public Rigidbody2D wave;
    public GameObject waveBreakText; 
    public TMP_Text countdownDisplay;
    private float countdown;
    public Pause checkPause;
    private bool P1AcquiredRipple = false;
    private bool P2AcquiredRipple = false;
    public Shop shop;
    public PlayerInfo player1;
    public PlayerInfo player2;
    
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        StartGame();
    }
    public void StartGame() {
        countdownDisplay.faceColor = new Color32(112,113,255,255);
        countdown = 2f;
        Time.timeScale = 1f;
        Update();
        waveBreakText.SetActive(false);
        wave = GetComponent<Rigidbody2D>();
        Invoke("WaveStart", 2);
    }
    void WaveStart(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
            wave.AddForce(new Vector2(10, Random.Range(-10, 10)));
        } 
        else {
            wave.AddForce(new Vector2(-10, Random.Range(-10, 10)));
        }
    }
    void Update() {
        countdown -= Time.deltaTime;
        countdownDisplay.text = countdown.ToString("0.0");
        if (countdown <= 0) {
            countdownDisplay.text = "GO";
            if (countdown <= -1) {
                countdownDisplay.faceColor = new Color32(105,179,233,0);
            }
        }
        // Check velocity to determine color
        if (wave.velocity.magnitude < 10) {
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color(119f/255f, 149f/255f, 202f/255f);
            }
            else if ( wave.velocity.magnitude > 10 && wave.velocity.magnitude < 20) {
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color(166f/255f, 52f/255f, 23f/255f);
            }
            else {
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 192f/255f);
            }

        // Check position to to determine who can hit the wave and add force
        if (wave.position.x < 0) { // left side
            if (Input.GetKeyDown("z") & waveInPlay() == true) {
                wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                if (wave.position.x > -2) {
                    wave.velocity = new Vector2(wave.velocity.x + 1, -wave.velocity.y);
                    if (P1AcquiredRipple == false) {
                        player1.gainRipple(1);
                    } 
                }
                else if (wave.position.x > -7) {
                    wave.velocity = new Vector2(wave.velocity.x + 2, -wave.velocity.y);
                    if (P1AcquiredRipple == false) {
                        player1.gainRipple(2);
                    }
                } 
                else {
                    wave.velocity = new Vector2(wave.velocity.x + 4, -wave.velocity.y);
                    if (P1AcquiredRipple == false) {
                        player1.gainRipple(3);
                    } 
                }
                P1AcquiredRipple = true;
                P2AcquiredRipple = false;
            }
        }
        else { // right side
            if (Input.GetKeyDown("m") & waveInPlay() == true) {
                wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                if (wave.position.x < 2) {
                    wave.velocity = new Vector2(wave.velocity.x - 1, -wave.velocity.y);
                     if (P2AcquiredRipple == false) {
                        player2.gainRipple(1);
                    }
                }
                else if (wave.position.x < 7) {
                    wave.velocity = new Vector2(wave.velocity.x - 2, -wave.velocity.y);
                    if (P2AcquiredRipple == false) {
                        player2.gainRipple(2);
                    }
                } 
                else {
                    wave.velocity = new Vector2(wave.velocity.x - 4, -wave.velocity.y);
                    if (P2AcquiredRipple == false) {
                        player2.gainRipple(3);
                    }
                }
                P2AcquiredRipple = true;
                P1AcquiredRipple = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "P1Base" | collision.gameObject.tag == "P2Base") {
            wave.velocity = new Vector2(0,0);
            wave.MovePosition(new Vector2(0,1));
            waveBreakText.SetActive(true);
            StartCoroutine(WaitForShop());
        }
    }
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    IEnumerator WaitForShop() {
        yield return new WaitForSeconds(2);
        waveBreakText.SetActive(false);
        shop.ShowShop();
    }
    public bool waveInPlay() {
        if ((checkPause.paused == false) & (countdown <= 0) & (waveBreakText.activeSelf == false) & (shop.inShop == false)) {
            return true;
        }
        else return false;
    }
}
