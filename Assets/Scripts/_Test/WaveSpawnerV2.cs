using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerV2 : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator SpawnEnemies() {
        while (true) {
            foreach (Transform spawnPoint in spawnPoints) {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}