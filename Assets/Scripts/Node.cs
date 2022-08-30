using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    private GameObject turret;

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

        if (buildManager.GetTurretToBuild() == null) {
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

        if (buildManager.GetTurretToBuild() == null) {
            return;
        }

        if (turret != null) {
            Debug.Log("Can't build here");
            return;
        }

        GameObject turretTobuild = buildManager.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretTobuild, transform.position + positionOffset, transform.rotation);
    }
}