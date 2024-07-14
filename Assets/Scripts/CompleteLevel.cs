using UnityEngine;

public class CompleteLevel : MonoBehaviour {
    [SerializeField] SceneFader sceneFader;

    private string menuScene = "MainMenu";

    [SerializeField] private string nextLevel = "Level02";
    [SerializeField] private int levelToUnlock = 2;

    public void Continue() {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu() {
        sceneFader.FadeTo(menuScene);
    }
}