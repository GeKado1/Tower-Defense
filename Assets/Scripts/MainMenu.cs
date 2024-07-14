using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string levelSelector = "LevelSelector";
    [SerializeField] SceneFader sceneFader;

    public void Play() {
        sceneFader.FadeTo(levelSelector);
    }
    
    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}