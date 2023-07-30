using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDie : MonoBehaviour {
    [SerializeField] private GameObject childEnemy;
    [SerializeField] private int numberOfChild;

    [HideInInspector] 
    public bool immortal;

    // Start is called before the first frame update
    void Start() {
        immortal = true;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SpawnChild(Transform _target, int currentWavePointIndex) {
        for (int i = 0; i < numberOfChild; i++) {
            GameObject spawnedEnemy = (GameObject) Instantiate(childEnemy, transform.position, Quaternion.identity);
            EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();

            enemyMovement.SetTarget(_target);
            enemyMovement.SetWavePointIndex(currentWavePointIndex);
        }
    }

    public int GetChild() {
        return numberOfChild;
    }
}