using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private Transform spawnedTarget;

    private Transform[] wayPoints;

    private int wavePointIndex;
    private int parentWavePointIndex;

    private bool haveRoute;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Enemy>();
        wavePointIndex = 0;

        haveRoute = false;
    }

    // Update is called once per frame
    void Update() {
        if (!haveRoute && wayPoints != null) {
            if (enemy.isSpawnedEnemy) {
                target = spawnedTarget;
                wavePointIndex = parentWavePointIndex;
            }
            else {
                target = wayPoints[0];
            }

            haveRoute = true;
        }
        else if (haveRoute && wayPoints != null){
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
                GetNextWayPoint();
            }

            enemy.speed = enemy.startSpeed;
        }
    }

    void GetNextWayPoint() {
        if (wavePointIndex >= wayPoints.Length - 1) {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = wayPoints[wavePointIndex];
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

    public void Path(Transform startPoint) {
        wayPoints = startPoint.GetComponent<StartPoints>().GetRoute();
    }
}