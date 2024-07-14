using UnityEngine;

public class WayPoints : MonoBehaviour {
    public Transform[] wayPoints;

    private void Awake() {
        wayPoints = new Transform[transform.childCount];

        for (int i = 0; i < wayPoints.Length; i++) {
            wayPoints[i] = transform.GetChild(i);
        }
    }

    public Transform[] ReturnWayPoints() {
        return wayPoints;
    }
}