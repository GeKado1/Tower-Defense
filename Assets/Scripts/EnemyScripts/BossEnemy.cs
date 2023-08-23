using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BossEnemy : MonoBehaviour {
    [SerializeField] private GameObject[] enemiesTypeList;
    [SerializeField] private float timeToSpawn;
    private float countdown;

    private EnemyMovement em;

    private int index = 0;
    private int numOfSpawned = 1;

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
            if (index >= enemiesTypeList.Length) {
                index = 0;
                numOfSpawned++;
            }

            em = GetComponent<EnemyMovement>();
            SpawnChild(em.GetTarget(), em.GetWavePointIndex()); ;
            countdown = timeToSpawn;

            index++;
        }

        countdown -= Time.deltaTime;
    }

    private void SpawnChild(Transform _target, int currentWavePointIndex) {
        for (int i = 0; i < numOfSpawned; i++) {
            GameObject spawnedEnemy = Instantiate(enemiesTypeList[index], transform.position, Quaternion.identity);
            EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();

            enemyMovement.SetTarget(_target);
            enemyMovement.SetWavePointIndex(currentWavePointIndex);

            WaveSpawner.enemiesAlive++;
        }
    }
}