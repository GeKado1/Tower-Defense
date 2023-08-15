using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnemy : MonoBehaviour {
    [SerializeField] private float heal;
    [SerializeField] private float healCountdown;
    private float countdown;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            healCountdown /= 2f;
        }

        enemy = GetComponent<Enemy>();
        countdown = healCountdown;
    }

    // Update is called once per frame
    void Update() {
        if (enemy.health < enemy.startHealth) {
            if (countdown <= 0f) {
                HealItself();
                countdown = healCountdown;
            }
        }

        countdown -= Time.deltaTime;
        Debug.Log(enemy.health);
    }

    private void HealItself() {
        float healAmount = enemy.startHealth - enemy.health;

        if (healAmount < heal) {
            enemy.health += healAmount;
        }
        else {
            enemy.health += heal;
        }
    }
}