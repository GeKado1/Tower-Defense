using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 0;
    [SerializeField] float enemyDistance = 0;
    [SerializeField] TextMeshProUGUI waveTimerText;

    private float countdown = 2;
    private int waveNum = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown = countdown - Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveTimerText.text = "Next wave: " + string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave() {
        waveNum++;
        PlayerStats.rounds++;

        for (int i = 0; i < waveNum; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(enemyDistance);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}