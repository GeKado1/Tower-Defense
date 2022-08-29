using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    BuildManager buildManager;

    // Start is called before the first frame update
    void Start() {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void PurchaseStandardTurret() {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret() {
        Debug.Log("Another Turret Selected");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}