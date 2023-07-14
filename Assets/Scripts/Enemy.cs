using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [SerializeField] private GameObject dieEffect;

    [Header("Enemy Stats")]
    public float startSpeed = 0;
    public float startHealth = 0;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float health;

    public int damage = 0;
    [SerializeField] private int moneyGiven = 0;

    [Header("Unity Stuff")]
    [SerializeField] private Image healthBar;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start() {
        speed = startSpeed;
        health = startHealth;
    }

    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(float dmgTaken) {
        health = health - dmgTaken;

        healthBar.fillAmount = health/startHealth;

        if (health <= 0 && !isDead) {
            Die();
        }
    }

    void Die() {
        isDead = true;

        PlayerStats.money = PlayerStats.money + moneyGiven;

        GameObject effect = (GameObject) Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }

    public void SpeedReduction(float speedReduction) {
        speed = startSpeed * (1f - speedReduction);
    }
}