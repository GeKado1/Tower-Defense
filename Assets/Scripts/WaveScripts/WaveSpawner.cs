using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public static int enemiesAlive = 0;

    [SerializeField] private GameManager gameManager;

    //[SerializeField] private Wave[] waves;
    [SerializeField] private WavesList[] wavesLists;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenWaves = 0;
    [SerializeField] private float initialTime = 0;
    [SerializeField] private TextMeshProUGUI waveTimerText;

    private float countdown = 0;
    private int waveNum = 0;

    private bool isSpawning;

    private bool initialWave = true;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(InitialWave());
        countdown = initialTime;

        waveTimerText.text = "Next wave: " + string.Format("{0:00.00}", countdown);

        if (GameManager.hardMode) {
            timeBetweenWaves *= 2;
        }
    }

    // Update is called once per frame
    void Update() {
        if (enemiesAlive > 0 && !GameManager.hardMode) {
            return;
        }

        if (!GameManager.hardMode) {
            if (waveNum == wavesLists[0].waves.Length && GameManager.gameEnd != true) {
                gameManager.WinLevel();
                enabled = false;
            }

            if (countdown <= 0f && initialWave != true) {
                StartCoroutine(SpawnWave());

                #if UNITY_EDITOR
                    Debug.Log("Starting wave " + (waveNum + 1));
                #endif

                countdown = timeBetweenWaves;
                return;
            }
        }
        else {
            if (enemiesAlive < 0 && waveNum >= wavesLists[0].waves.Length) {
                gameManager.WinLevel();
                enabled = false;
            }

            if (!isSpawning && waveNum < wavesLists[0].waves.Length) {
                if (countdown <= 0f && initialWave != true) {
                    for (int i = 0; i < wavesLists.Length; i++) {
                        StartCoroutine(SpawnWave(wavesLists[i].waves[waveNum]));
                    }

                    //StartCoroutine(SpawnWave(waves[waveNum]));

                    #if UNITY_EDITOR
                        Debug.Log("Starting wave " + (waveNum + 1));
                    #endif

                    countdown = timeBetweenWaves;
                    return;
                }
            }

            if (enemiesAlive < 0) {
                enemiesAlive = 0;
            }
        }

        if (GameManager.gameEnd == true) {
            enabled = false;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveTimerText.text = "Next wave: " + string.Format("{0:00.00}", countdown);

        #if UNITY_EDITOR
            Debug.Log("Enemies alive: " + enemiesAlive);
        #endif
    }

    IEnumerator SpawnWave() {
        PlayerStats.rounds++;

        int wavesListNum = wavesLists.Length;

        if (waveNum < wavesLists[0].waves.Length) {
            Wave[] moreThanOneWave = new Wave[wavesListNum];

            for (int i = 0; i < moreThanOneWave.Length; i++) {
                moreThanOneWave[i] = wavesLists[i].waves[waveNum];

                #if UNITY_EDITOR
                    Debug.Log("multiple wave num: " + waveNum + " waves length: " + wavesLists[i].waves.Length + " wave list: " + i);
                #endif
            }

            //SAME

            /*Wave wave = waves[waveNum];

            #if UNITY_EDITOR
                Debug.Log("wave num: " + waveNum + " waves length: " + waves.Length);
            #endif*/


            //---//


            if (!GameManager.hardMode) {
                for (int i = 0; i < moreThanOneWave.Length; i++) {
                    enemiesAlive += enemiesAlive + moreThanOneWave[i].count;
                }

                //enemiesAlive = wave.count * spawnPoints.Length;
            }

            for (int i = 0; i < wavesLists.Length; i++) {
                for (int j = 0; j < moreThanOneWave[i].count; j++) {
                    SpawnEnemy(moreThanOneWave[i].enemy);

                    yield return new WaitForSeconds(1f / moreThanOneWave[i].rate);
                }
            }

           

            /*for (int i = 0; i < wave.count; i++) {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }*/


            //---//


            waveNum++;
        }
    }

    IEnumerator SpawnWave(Wave wave) {
        PlayerStats.rounds++;

        isSpawning = true;

        enemiesAlive += wave.count * spawnPoints.Length;

        for (int i = 0; i <= wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        isSpawning = false;
        waveNum++;
    }

    void SpawnEnemy(GameObject enemy) {
        for (int i = 0; i < spawnPoints.Length; i++) {
            GameObject e = Instantiate(enemy, spawnPoints[i].position, spawnPoints[i].rotation);
            e.GetComponent<EnemyMovement>().Path(spawnPoints[i]);
        }
    }

    IEnumerator InitialWave() {
        yield return new WaitForSeconds(initialTime);
        initialWave = false;
        StartCoroutine(SpawnWave());
        countdown = timeBetweenWaves;
    }
}