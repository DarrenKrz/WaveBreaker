using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Rigidbody2D wave;
    private int rippleCount = 0;
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
        // test addition
        // Check position to add force
        if (Input.GetKeyDown("space")) {
            if (wave.position.x < 0) {
                if (wave.position.x > -2) {
                    rippleCount += 1;
                    wave.AddForce(new Vector2(10, 0));
                }
                else if (wave.position.x > -7) {
                    rippleCount += 2;
                    wave.AddForce(new Vector2(20, 0));
                } 
                else {
                    rippleCount += 3;
                    wave.AddForce(new Vector2(40, 0));
                }
            } 
            else {
                if (wave.position.x < 2) {
                    rippleCount += 1;
                    wave.AddForce(new Vector2(-10, 0));
                }
                else if (wave.position.x < 7) {
                    rippleCount += 2;
                    wave.AddForce(new Vector2(-20, 0));
                } 
                else {
                    rippleCount += 3;
                    wave.AddForce(new Vector2(-40, 0));
                }
            }
            if (wave.velocity.magnitude < 10) {
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color(119f/255f, 149f/255f, 202f/255f);
            }
            else if ( wave.velocity.magnitude > 10 && wave.velocity.magnitude < 20) {
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color(166f/255f, 52f/255f, 23f/255f);
            }
            else {
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 192f/255f);
            }
        }
    }
}