using UnityEngine;

public class StartPoints : MonoBehaviour {
    [SerializeField] private Transform SP_Transform;
    [SerializeField] private WayPoints wayPoints;
    [HideInInspector] public Transform[] routeToFollow;

    // Start is called before the first frame update
    void Start() {
        routeToFollow = wayPoints.wayPoints;
    }

    public Transform[] GetRoute() {
        return routeToFollow;
    }
}