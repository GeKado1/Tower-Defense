using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private Transform spawnedTarget;

    private int wavePointIndex;
    private int parentWavePointIndex;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Enemy>();
        wavePointIndex = 0;

        if (enemy.isSpawnedEnemy) {
            target = spawnedTarget;
            wavePointIndex = parentWavePointIndex;
        }
        else {
            target = WayPoints.wayPoints[0];
        }
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
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
            PlayerStats.lives = PlayerStats.lives - enemy.damage;
        }

        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

    public void SetTarget (Transform _target) {
        spawnedTarget = _target;
    }

    public Transform GetTarget() {
        return target;
    }

    public void SetWavePointIndex(int index) {
        parentWavePointIndex = index;
    }

    public int GetWavePointIndex() {
        return wavePointIndex;
    }
}