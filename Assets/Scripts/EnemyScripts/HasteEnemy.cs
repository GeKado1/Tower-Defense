using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteEnemy : MonoBehaviour {
    [SerializeField] private float speedBoost = 0;
    private Enemy enemy;
    private float dmgTaken = 0;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            speedBoost *= 2f;
        }

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SpeedUp(float _dmgTaken) {
        dmgTaken += _dmgTaken;

        if (dmgTaken >= 25) {
            Debug.Log("speed boost");
            enemy.startSpeed += speedBoost;
            dmgTaken = 0;
        }
    }
}