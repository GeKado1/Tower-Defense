using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (PlayerStats.lives <= 0 && gameEnd == false) {
            EndGame();
        }
    }

    void EndGame() {
        Debug.Log("Game Over!");
        gameEnd = true;
    }
}