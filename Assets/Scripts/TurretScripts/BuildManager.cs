using UnityEngine;

public class BuildManager : MonoBehaviour {
    //Type of turret
    private TurretBlueprint turretToBuild;

    //Node selected with their UI
    private Node selectNode;
    public NodeUI nodeUI;

    public static BuildManager instance;

    //Build and Sell Effects
    public GameObject buildEffect;
    public GameObject sellEffect;

    public static GameObject build_Effect;
    public static GameObject sell_Effect;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    void Awake() {
        if (instance != null) {
            #if UNITY_EDITOR
                Debug.Log("More than one Build Manager in scene");
            #endif

            return;
        }

        instance = this;

        build_Effect = buildEffect;
        sell_Effect = sellEffect;
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