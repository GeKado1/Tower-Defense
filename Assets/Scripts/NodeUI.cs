using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour {
    private Node target;

    public GameObject ui;

    // Start is called before the first frame update
    void Start() {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetTarget(Node targetNode) {
        target = targetNode;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }
}