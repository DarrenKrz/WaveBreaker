using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wave : MonoBehaviour
{
    private Rigidbody2D wave;
    private int P1rippleCount = 0;
    private int P2rippleCount = 0;
    public TMP_Text P1RippleText;
    public TMP_Text P2RippleText;
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
        if (wave.position.x < 0) {
            if (Input.GetKeyDown("z")) {
                if (wave.position.x > -2) {
                    P1rippleCount += 1;
                    wave.AddForce(new Vector2(10, 0));
                    P1RippleText.text = P1rippleCount.ToString();
                }
                else if (wave.position.x > -7) {
                    P1rippleCount += 2;
                    wave.AddForce(new Vector2(20, 0));
                    P1RippleText.text = P1rippleCount.ToString();
                } 
                else {
                    P1rippleCount += 3;
                    wave.AddForce(new Vector2(40, 0));
                    P1RippleText.text = P1rippleCount.ToString();
                }
            }
        } 
        else {
            if (Input.GetKeyDown("m")) {
                if (wave.position.x < 2) {
                    P2rippleCount += 1;
                    wave.AddForce(new Vector2(-10, 0));
                    P2RippleText.text = P2rippleCount.ToString();
                }
                else if (wave.position.x < 7) {
                    P2rippleCount += 2;
                    wave.AddForce(new Vector2(-20, 0));
                    P2RippleText.text = P2rippleCount.ToString();
                } 
                else {
                    P2rippleCount += 3;
                    wave.AddForce(new Vector2(-40, 0));
                    P2RippleText.text = P2rippleCount.ToString();
                }
            }
        }
    }
}