using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private GameObject dieEffect;

    [Header("Enemy Stats")]
    public float startSpeed = 0;
    [HideInInspector]
    public float speed;

    public int damage = 0;
    [SerializeField] private float health = 0;
    [SerializeField] private int moneyGiven = 0;

    // Start is called before the first frame update
    void Start() {
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(float dmgTaken) {
        health = health - dmgTaken;

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        PlayerStats.money = PlayerStats.money + moneyGiven;

        GameObject effect = (GameObject) Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    public void SpeedReduction(float speedReduction) {
        speed = startSpeed * (1f - speedReduction);
    }
}