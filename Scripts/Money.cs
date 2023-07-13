using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour {
    [SerializeField] TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        moneyText.text = "Money: $" + PlayerStats.money;
    }
}