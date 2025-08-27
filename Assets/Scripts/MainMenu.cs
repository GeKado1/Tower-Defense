using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string levelSelector = "LevelSelector";
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private GameObject settings;

    [SerializeField] private TMPro.TMP_Dropdown resolutionsDropdown;

    private Resolution[] resolutions;

    private void Start() {
        settings.SetActive(false);

        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
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

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;

        #if UNITY_EDITOR
            Debug.Log(isFullscreen);
        #endif
    }

    public void Quit() {
        #if UNITY_EDITOR
            Debug.Log("Exiting...");
        #endif

        Application.Quit();
    }
}