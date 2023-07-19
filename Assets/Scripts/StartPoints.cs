using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoints : MonoBehaviour {
    [SerializeField] private Transform SP_Transform;
    [SerializeField] private WayPoints wayPoints;
    [SerializeField] private static WayPoints routeToFollow;

    // Start is called before the first frame update
    void Start() {
        routeToFollow = wayPoints;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public Transform getStartPointTransform() {
        return transform;
    }

    public static WayPoints getRoute() {
        return routeToFollow;
    }
}