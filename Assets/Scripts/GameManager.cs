using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool gameEnd;

    public static bool hardMode = false;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject completeLevel;

    // Start is called before the first frame update
    void Start() {
        gameOver.SetActive(false);
        gameEnd = false;
        Debug.Log(hardMode);
    }

    // Update is called once per frame
    void Update() {
        if (PlayerStats.lives <= 0 && gameEnd == false) {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            ChangeDifficulty();
            Debug.Log(hardMode);
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

    private void ChangeDifficulty() {
        hardMode = !hardMode;
    }
}