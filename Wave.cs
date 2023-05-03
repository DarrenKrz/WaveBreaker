using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wave : MonoBehaviour
{
    private Rigidbody2D wave;
    private int P1RippleCount = 0;
    private int P2RippleCount = 0;
    public TMP_Text P1RippleText;
    public TMP_Text P2RippleText;
    private bool reflectedWave;
    void GoBall(){
        float rand = Random.Range(0, 2);
            if(rand < 1){
                wave.AddForce(new Vector2(10, -8));
            } 
            else {
                wave.AddForce(new Vector2(-10, -8));
            }
    }

    void Start() {
        wave = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 0);
    }

    void Update() {
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
            if (Input.GetKeyDown("z")) {
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
            if (Input.GetKeyDown("m")) { // right side
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
            Debug.Log("ResetWave");
        }
    }
}