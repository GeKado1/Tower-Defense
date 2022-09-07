using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    //Type of turret
    private TurretBlueprint turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLaunchePrefab;
    public bool CanBuild { get { return turretToBuild != null; } }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void Awake() {
        if (instance != null) {
            Debug.Log("More than one Build Manager in scene");
            return;
        }
        instance = this;
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node) {
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}