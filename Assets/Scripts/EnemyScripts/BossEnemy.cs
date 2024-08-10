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
            em = GetComponent<EnemyMovement>();

            if (index >= enemiesTypeList.Length) {
                index = 0;
                numOfSpawned++;
            }

            SpawnChild(em.GetTarget(), em.GetWavePointIndex(), em.GetParentWayPoints()); ;
            countdown = timeToSpawn;

            index++;
        }

        countdown -= Time.deltaTime;
    }

    private void SpawnChild(Transform _target, int currentWavePointIndex, Transform[] wayPoints) {
        for (int i = 0; i < numOfSpawned; i++) {
            GameObject spawnedEnemy = Instantiate(enemiesTypeList[index], transform.position, Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().startSpeed -= i * 0.1f;
            spawnedEnemy.GetComponent<Enemy>().isSpawnedEnemy = true;

            EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
            enemyMovement.SetTarget(_target);
            enemyMovement.SetWavePointIndex(currentWavePointIndex);
            enemyMovement.SetChildWaypoints(wayPoints);

            //WaveSpawner.enemiesAlive++;
        }
    }
}