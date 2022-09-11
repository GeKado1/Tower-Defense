using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float speed = 0;
    [SerializeField] private int damage = 0;

    private Transform target;
    private int wavePointIndex = 0;

    // Start is called before the first frame update
    void Start() {
        target = WayPoints.wayPoints[0];
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint() {
        if (wavePointIndex >= WayPoints.wayPoints.Length - 1) {
            if (PlayerStats.lives > 0) {
                PlayerStats.lives = PlayerStats.lives - damage;
            }
            else {
                Debug.Log("You die");
            }

            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = WayPoints.wayPoints[wavePointIndex];
    }
}