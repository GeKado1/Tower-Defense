using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int money;
    public static int lives;
    public static int rounds;

    [SerializeField] private int startMoney = 0;
    [SerializeField] private int startLives = 0;

    // Start is called before the first frame update
    void Start() {
        money = startMoney;
        lives = startLives;
        rounds = 0;
    }

    // Update is called once per frame
    void Update() {
        
    }
}