using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOver;

    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start() {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (PlayerStats.lives <= 0 && gameEnd == false) {
            EndGame();
        }
    }

    void EndGame() {
        gameOver.SetActive(true);
        Debug.Log("Game Over!");
        gameEnd = true;
    }
}