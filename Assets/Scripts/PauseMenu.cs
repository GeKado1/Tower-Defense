using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] GameObject ui;
    [SerializeField] SceneFader sceneFader;

    private string menuScene = "MainMenu";

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            Toggle();
        }
    }

    public void Toggle() {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf) {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

    public void Retry() {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        Toggle();
        sceneFader.FadeTo(menuScene);
    }
}