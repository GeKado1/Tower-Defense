using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour {
    [SerializeField] TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update() {
        livesText.text = "Lives: " + PlayerStats.lives;
    }
}