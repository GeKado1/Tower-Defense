using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool gameEnd;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject completeLevel;

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

    public void WinLevel() {
        completeLevel.SetActive(true);
        gameEnd = true;
    }
}