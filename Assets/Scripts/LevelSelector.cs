using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {
    [SerializeField] private SceneFader fader;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Select(string levelName) {
        fader.FadeTo(levelName);
    }
}