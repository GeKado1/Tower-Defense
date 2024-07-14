using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySpawnDie : MonoBehaviour {
    [SerializeField] private GameObject childEnemy;
    [SerializeField] private int numberOfChild;

    [SerializeField] private Transform[] childRoute;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode){
            numberOfChild++;
        }
    }

    public void SpawnChild(Transform _target, int currentWavePointIndex, Transform[] wayPoints) {
        for (int i = 0; i < numberOfChild; i++) {
            GameObject spawnedEnemy = Instantiate(childEnemy, transform.position, Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().startSpeed -= i + 1;

            EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
            enemyMovement.SetTarget(_target);
            enemyMovement.SetWavePointIndex(currentWavePointIndex);
            enemyMovement.SetChildWaypoints(wayPoints);
        }
    }

    public int GetChild() {
        return numberOfChild;
    }
}