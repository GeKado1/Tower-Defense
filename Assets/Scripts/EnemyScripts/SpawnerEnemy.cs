using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SpawnerEnemy : MonoBehaviour {
    [SerializeField] private GameObject childEnemy;
    [SerializeField] private float timeToSpawn;
    private float countdown;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            timeToSpawn -= 2f;
        }

        countdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update() {
        if (countdown <= 0f) {
            SpawnChild();
            countdown = timeToSpawn;
        }

        countdown -= Time.deltaTime;
    }

    private void SpawnChild() {
        GameObject spawnedEnemy = Instantiate(childEnemy, transform.position, Quaternion.identity);
        EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();

        enemyMovement.SetTarget(enemyMovement.GetTarget());
        enemyMovement.SetWavePointIndex(enemyMovement.GetWavePointIndex());
    }
}