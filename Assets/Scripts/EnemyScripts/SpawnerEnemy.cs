using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SpawnerEnemy : MonoBehaviour {
    [SerializeField] private GameObject childEnemy;
    [SerializeField] private float timeToSpawn;
    private float countdown;

    private EnemyMovement em;

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
            SpawnChild(em.GetTarget(), em.GetWavePointIndex(), em.GetParentWayPoints());
            countdown = timeToSpawn;
        }

        countdown -= Time.deltaTime;
    }

    private void SpawnChild(Transform _target, int currentWavePointIndex, Transform[] wayPoints) {
        GameObject spawnedEnemy = Instantiate(childEnemy, transform.position, Quaternion.identity);
        EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();

        enemyMovement.SetTarget(_target);
        enemyMovement.SetWavePointIndex(currentWavePointIndex);
        enemyMovement.SetChildWaypoints(wayPoints);

        //WaveSpawner.enemiesAlive++;
    }
}