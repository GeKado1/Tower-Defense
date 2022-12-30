using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI roundsText;
    [SerializeField] private SceneFader sceneFader;
    //[SerializeField] private GameObject ui;

    private string menuScene = "MainMenu";

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnEnable() {
        roundsText.SetText((PlayerStats.rounds).ToString());
    }

    public void Retry() {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        sceneFader.FadeTo(menuScene);
    }

    /*public void Toggle() {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf) {
            Time.timeScale = 0f;
        }
    }*/
}