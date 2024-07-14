using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    [SerializeField] private SceneFader sceneFader;

    private string menuScene = "MainMenu";

    public void Retry() {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        sceneFader.FadeTo(menuScene);
    }
}