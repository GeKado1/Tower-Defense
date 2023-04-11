using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {
    public static int enemiesAlive = 0;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Wave[] waves;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenWaves = 0;
    [SerializeField] private TextMeshProUGUI waveTimerText;

    private float countdown = 2;
    private int waveNum = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (enemiesAlive > 0) {
            return;
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
        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        
        waveNum++;

        if (waveNum == waves.Length) {
            while (enemiesAlive > 0) {
                yield return new WaitForSeconds(0.5f);
            }

            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}