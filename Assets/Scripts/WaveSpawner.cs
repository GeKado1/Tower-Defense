using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {
    public static int enemiesAlive = 0;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Wave[] waves;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenWaves = 0;
    [SerializeField] private TextMeshProUGUI waveTimerText;

    private float countdown = 2;
    private int waveNum = 0;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnWave());
        countdown = timeBetweenWaves;

        waveTimerText.text = "Next wave: " + string.Format("{0:00.00}", countdown);
    }

    // Update is called once per frame
    void Update() {
        if (enemiesAlive > 0) {
            return;
        }

        if (waveNum == waves.Length && GameManager.gameEnd != true) {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (GameManager.gameEnd == true) {
            this.enabled = false;
        }

        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown = countdown - Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveTimerText.text = "Next wave: " + string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave() {
        PlayerStats.rounds++;

        Wave wave = waves[waveNum];
        enemiesAlive = wave.count * spawnPoints.Length;

        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        
        waveNum++;
    }

    void SpawnEnemy(GameObject enemy) {
        for (int i = 0; i < spawnPoints.Length; i++) {
            Instantiate(enemy, spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }
}