using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour {
    [SerializeField] private float speed = 5f;
    private List<Transform> currentRoute;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start() {
        if (GetComponent<StartPointsV2>()) {
            currentRoute = GetComponent<StartPointsV2>().initialRoute;
        }

        SetTargetWaypoint(currentWaypointIndex);
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction = currentRoute[currentWaypointIndex].position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentRoute[currentWaypointIndex].position) < 0.2f) {
            SetTargetWaypoint(currentWaypointIndex);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void SetTargetWaypoint(int index) {
        currentWaypointIndex = index;
        transform.LookAt(currentRoute[currentWaypointIndex]);
    }
}