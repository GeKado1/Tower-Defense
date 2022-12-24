using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    //Type of turret
    private TurretBlueprint turretToBuild;
    private Node selectNode;

    public static BuildManager instance;
    public static GameObject buildEffect;

    public NodeUI nodeUI;
    public GameObject effect;

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
        buildEffect = effect;
    }

    public void SelectNode(Node node) {
        if (selectNode == node) {
            DeselectNode();
            return;
        }

        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild() {
        return turretToBuild;
    }
}