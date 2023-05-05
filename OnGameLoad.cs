using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnGameLoad : MonoBehaviour
{
    public Rigidbody2D wave;
    private int P1RippleCount = 0;
    private int P2RippleCount = 0;
    public TMP_Text P1RippleText;
    public TMP_Text P2RippleText;
    public TMP_Text waveBreakText; 
    public TMP_Text countdownDisplay;
    private float countdown;
    public Pause checkPause;
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        waveBreakText.faceColor = new Color32(112,113,255,0);
        StartGame();
    }
    public void StartGame() {
        countdownDisplay.faceColor = new Color32(112,113,255,255);
        countdown = 2f;
        Update();
        waveBreakText.faceColor = new Color32(112,113,255,0);
        wave = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        Invoke("GoBall", 2);
    }
    void GoBall(){
        float rand = Random.Range(0, 2);
            if(rand < 1){
                wave.AddForce(new Vector2(10, -8));
            } 
            else {
                wave.AddForce(new Vector2(-10, -8));
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

        // Check position to to determine who can hit the ball and add force
        if (wave.position.x < 0) { // left side
            if (Input.GetKeyDown("z") & checkPause.paused == false) {
                if (wave.position.x > -2) {
                    P1RippleCount += 1;
                    wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                    wave.velocity = new Vector2(wave.velocity.x + 1, -wave.velocity.y);
                    P1RippleText.text = P1RippleCount.ToString();
                }
                else if (wave.position.x > -7) {
                    P1RippleCount += 2;
                    wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                    wave.velocity = new Vector2(wave.velocity.x + 2, -wave.velocity.y);
                    P1RippleText.text = P1RippleCount.ToString();
                } 
                else {
                    P1RippleCount += 3;
                    wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                    wave.velocity = new Vector2(wave.velocity.x + 4, -wave.velocity.y);
                    P1RippleText.text = P1RippleCount.ToString();
                }
            }
        }
        else {
            if (Input.GetKeyDown("m") & checkPause.paused == false) { // right side
                if (wave.position.x < 2) {
                    P2RippleCount += 1;
                    wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                    wave.velocity = new Vector2(wave.velocity.x - 1, -wave.velocity.y);
                    P2RippleText.text = P2RippleCount.ToString();
                }
                else if (wave.position.x < 7) {
                    P2RippleCount += 2;
                    wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                    wave.velocity = new Vector2(wave.velocity.x - 2, -wave.velocity.y);
                    P2RippleText.text = P2RippleCount.ToString();
                } 
                else {
                    P2RippleCount += 3;
                    wave.velocity = Vector2.Reflect(wave.velocity, wave.velocity.normalized);
                    wave.velocity = new Vector2(wave.velocity.x - 4, -wave.velocity.y);
                    P2RippleText.text = P2RippleCount.ToString();
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "P1Base" | collision.gameObject.tag == "P2Base") {
            wave.velocity = new Vector2(0,0);
            wave.MovePosition(new Vector2(0,1));
            Invoke("StartGame", 1);
            waveBreakText.faceColor = new Color32(112,113,255,255);
        }
    }
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
