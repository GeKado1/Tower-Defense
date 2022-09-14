using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    //Type of turret
    private TurretBlueprint turretToBuild;

    public static BuildManager instance;

    [SerializeField] private GameObject buildEffect;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

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
        if (PlayerStats.money < turretToBuild.cost) {
            Debug.Log("Not enought money to build that!");
            return;
        }

        PlayerStats.money = PlayerStats.money - turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.money);
    }
}