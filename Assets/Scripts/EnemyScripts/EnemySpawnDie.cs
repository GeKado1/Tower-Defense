using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySpawnDie : MonoBehaviour {
    [SerializeField] private GameObject childEnemy;
    [SerializeField] private int numberOfChild;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode){
            numberOfChild++;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SpawnChild(Transform _target, int currentWavePointIndex) {
        for (int i = 0; i < numberOfChild; i++) {
            GameObject spawnedEnemy = Instantiate(childEnemy, transform.position, Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().startSpeed -= i + 1;

            EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
            enemyMovement.SetTarget(_target);
            enemyMovement.SetWavePointIndex(currentWavePointIndex);
        }
    }

    public int GetChild() {
        return numberOfChild;
    }
}