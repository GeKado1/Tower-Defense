using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    BuildManager buildManager;

    [SerializeField] TurretBlueprint standardTurret;
    [SerializeField] TurretBlueprint missileLauncher;

    // Start is called before the first frame update
    void Start() {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}