using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    private GameObject turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLaunchePrefab;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public GameObject GetTurretToBuild() {
        return turretToBuild;
    }

    void Awake() {
        if (instance != null) {
            Debug.Log("More than one Build Manager in scene");
            return;
        }
        instance = this;
    }

    public void SetTurretToBuild(GameObject turret) {
        turretToBuild = turret;
    }
}