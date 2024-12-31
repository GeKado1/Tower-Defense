using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    [SerializeField] private SceneFader fader;

    [SerializeField] Button[] levelButtons;
    [SerializeField] private GameObject difficultyButtons;

    [SerializeField] private GameObject testButton;

    private string levelName;

    // Start is called before the first frame update
    void Start() {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++) {
            if (i + 1 > levelReached) {
                levelButtons[i].interactable = false;
            }
        }

        #if UNITY_EDITOR
            activeTestLevel();
        #endif
    }

    // Update is called once per frame
    void Update() {
        #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.L)) {
                unlockDevLevel();
            }
        #endif
    }

    public void Select(string levelName) {
        fader.FadeTo(levelName);
    }

    public void ToMainMenu() {
        fader.FadeTo("MainMenu");
    }

    public void SelectDifficulty(string _levelName) {
        difficultyButtons.SetActive(true);
        levelName = _levelName;
    }

    public void SetDifficulty(bool isHard) {
        if (isHard) {
            GameManager.hardMode = true;
        }
        else {
            GameManager.hardMode = false;
        }

        Select(levelName);
    }

    private void unlockDevLevel() {
        for (int i = 0; i < levelButtons.Length; i++) {
                levelButtons[i].interactable = true;
        }
    }

    private void activeTestLevel() {
        testButton.SetActive(true);
    }
}