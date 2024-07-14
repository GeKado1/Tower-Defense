using TMPro;
using UnityEngine;

public class Money : MonoBehaviour {
    [SerializeField] TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update() {
        moneyText.text = "Money: $" + PlayerStats.money;
    }
}