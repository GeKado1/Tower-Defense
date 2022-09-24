using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOver;

    public static bool gameEnd;

    // Start is called before the first frame update
    void Start() {
        gameOver.SetActive(false);
        gameEnd = false;
    }

    // Update is called once per frame
    void Update() {
        if (PlayerStats.lives <= 0 && gameEnd == false) {
            EndGame();
        }
    }

    void EndGame() {
        gameOver.SetActive(true);
        gameEnd = true;
    }
}