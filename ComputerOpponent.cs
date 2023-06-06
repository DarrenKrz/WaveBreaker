using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerOpponent : MonoBehaviour
{
    public bool computerInPlay;
    public Rigidbody2D wave;
    public OnGameLoad gameState;
    public bool computerHitWave;

    public void vsComputer() {
        computerInPlay = true;
        computerHitWave = false;
    }
    public void onComputerSide() {
        int hitBall = Random.Range(1,20);
        if (hitBall != 1) {
            if (wave.position.x < 2 & (hitBall > 2 & hitBall < 10)) {
                
            }
            else if ((wave.position.x < 7 & hitBall > 2) & (hitBall > 2 & hitBall < 10)) {

            }
            else if (wave.position.x > 7 & (hitBall > 2 & hitBall < 10)) {

            }
        }
        else {
            
        }
    }
}