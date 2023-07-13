using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour {
    [SerializeField] TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        livesText.text = "Lives: " + PlayerStats.lives;
    }
}