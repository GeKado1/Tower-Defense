using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!buildManager.CanBuild) {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }

    private void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!buildManager.CanBuild) {
            return;
        }

        if (turret != null) {
            Debug.Log("Can't build here");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}