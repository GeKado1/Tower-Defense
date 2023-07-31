using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    [SerializeField] private SceneFader fader;
    [SerializeField] Button[] levelButtons;
    [SerializeField] private GameObject difficultyButtons;

    private string levelName;

    // Start is called before the first frame update
    void Start() {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++) {
            if (i + 1 > levelReached) {
                levelButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
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
}