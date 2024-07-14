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

    [Header("Differents Types of Enemies")]
    [SerializeField] private bool isDieEnemy;
    public bool isSpawnedEnemy;

    [SerializeField] private bool isHasteEnemy;

    [SerializeField] private bool isArmouredEnemy;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            HardMode();
        }
        else {
            speed = startSpeed;
            health = startHealth;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void TakeDamage(float dmgTaken) {
        if (isArmouredEnemy) {
            ArmouredEnemy ae = GetComponent<ArmouredEnemy>();
            ae.TakeDamage(dmgTaken);
        }
        else {
            health -= dmgTaken;
        }

        if (isHasteEnemy) {
            HasteEnemy he = GetComponent<HasteEnemy>();
            he.SpeedUp(dmgTaken);
        }

        healthBar.fillAmount = health/startHealth;

        if (health <= 0 && !isDead) {
            Die();
        }
    }

    void Die() {
        isDead = true;

        PlayerStats.money = PlayerStats.money + moneyGiven;

        if (isDieEnemy) {
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

            EnemySpawnDie enemySpawnDie = GetComponent<EnemySpawnDie>();
            enemySpawnDie.SpawnChild(enemyMovement.GetTarget(), enemyMovement.GetWavePointIndex(), enemyMovement.GetParentWayPoints());

            WaveSpawner.enemiesAlive += GetComponent<EnemySpawnDie>().GetChild();
        }

        GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }

    public void SpeedReduction(float speedReduction) {
        if (!isHasteEnemy) {
            speed = startSpeed * (1f - speedReduction);
        }
    }

    private void HardMode() {
        health = startHealth * 2;
        startHealth *= 2;
        damage *= 2;
        moneyGiven *= 2;
    }
}