using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDie : MonoBehaviour {
    [SerializeField] private GameObject childEnemy;
    [SerializeField] private int numberOfChild;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SpawnChild() {
        for (int i = 0; i < numberOfChild; i++) {
            GameObject spawnedEnemy = (GameObject) Instantiate(childEnemy, transform.position, Quaternion.identity);
            //spawnedEnemy.GetComponent<EnemyMovement>().SetTarget(GetComponent<EnemyMovement>().GetTarget());
        }
    }

    public int GetChild()
    {
        return numberOfChild;
    }
}