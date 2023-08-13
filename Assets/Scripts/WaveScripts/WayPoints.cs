using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {
    public static Transform[] wayPoints;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void Awake() {
        wayPoints = new Transform[transform.childCount];

        for (int i = 0; i < wayPoints.Length; i++) {
            wayPoints[i] = transform.GetChild(i);
        }
    }
}