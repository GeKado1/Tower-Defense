using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI loseText;

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

        if (Input.GetKeyDown("e")) {
            EndGame();
        }
    }

    void EndGame() {
        gameOver.SetActive(true);
        gameEnd = true;
        if (PlayerStats.rounds != 0) {
            loseText.SetText((PlayerStats.rounds - 1).ToString());
        }
        else {
            loseText.SetText(PlayerStats.rounds.ToString());
        }
    }
}