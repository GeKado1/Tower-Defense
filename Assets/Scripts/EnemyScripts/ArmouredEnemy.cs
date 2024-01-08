using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmouredEnemy : MonoBehaviour {
    [SerializeField] private float dmgReduction;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            if (dmgReduction < 0.5f) {
                dmgReduction *= 2;
            }
        }

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void TakeDamage(float dmgTaken) {
        enemy.health -= dmgTaken * (1f - dmgReduction);
    }
}