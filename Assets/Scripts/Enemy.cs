using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float speed = 0;
    [SerializeField] private int damage = 0;
    [SerializeField] private float health = 0;
    [SerializeField] private int money = 0;

    [SerializeField] private GameObject dieEffect;

    private Transform target;
    private int wavePointIndex = 0;

    // Start is called before the first frame update
    void Start() {
        target = WayPoints.wayPoints[0];
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint() {
        if (wavePointIndex >= WayPoints.wayPoints.Length - 1) {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = WayPoints.wayPoints[wavePointIndex];
    }

    void EndPath() {
        if (PlayerStats.lives > 0) {
            PlayerStats.lives = PlayerStats.lives - damage;
        }

        Destroy(gameObject);
    }

    public void TakeDamage(int dmgTaken) {
        health = health - dmgTaken;

        if (health <= 0) {
            Die();
        }
    }

    public void TakeDamage(float dmgTaken) {
        health = health - dmgTaken;

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        PlayerStats.money = PlayerStats.money + money;

        GameObject effect = (GameObject) Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
}