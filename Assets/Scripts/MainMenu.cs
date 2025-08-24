using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string levelSelector = "LevelSelector";
    [SerializeField] SceneFader sceneFader;
    [SerializeField] private GameObject settings;

    private void Start() {
        settings.SetActive(false);
    }

    public void Play() {
        sceneFader.FadeTo(levelSelector);
    }

    public void Settings() {
        settings.SetActive(!settings.activeSelf);
    }

    public void SetVolume(float volume) {
        Debug.Log(volume);
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Quit() {
        #if UNITY_EDITOR
            Debug.Log("Exiting...");
        #endif

        Application.Quit();
    }
}