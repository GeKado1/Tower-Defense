using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string levelToLoad = "MainLevel";

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play() {
        SceneManager.LoadScene(levelToLoad);
    }
    
    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}