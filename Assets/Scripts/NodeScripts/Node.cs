using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    //Variables of colors to notify the Player where are going to place the turrets
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notEnoughtMoneyColor;
    [SerializeField] private Vector3 positionOffset;

    [SerializeField] private bool isBlockedNode;

    private Renderer rend;
    private Color startColor;

    //Variables for Build or Upgrade the Turret on the Node (if there is one)
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgradedToLvl2 = false;
    [HideInInspector]
    public bool isUpgradedToLvl3 = false;

    BuildManager buildManager;

    void Start() {
        if (!isBlockedNode) {
            rend = GetComponent<Renderer>();
            startColor = rend.material.color;
            buildManager = BuildManager.instance;
        }
    }

    private void OnMouseEnter() {
        if (!isBlockedNode) {
            if (EventSystem.current.IsPointerOverGameObject()) {
                return;
            }

            if (!buildManager.CanBuild) {
                return;
            }

            if (!buildManager.HasMoney) {
                rend.material.color = notEnoughtMoneyColor;
            }
            else {
                rend.material.color = hoverColor;
            }
        }
    }

    private void OnMouseExit() {
        if (!isBlockedNode) {
            rend.material.color = startColor;
        }
    }

    private void OnMouseDown() {
        if (!isBlockedNode) {
            if (EventSystem.current.IsPointerOverGameObject()) {
                return;
            }

            if (turret != null) {
                buildManager.SelectNode(this);
                return;
            }

            if (!buildManager.CanBuild) {
                return;
            }

            BuildTurret(buildManager.GetTurretToBuild());
        }
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint) {
        BuffNode bn = GetComponent<BuffNode>();

        if (PlayerStats.money < blueprint.cost) {
            Debug.Log("Not enought money to build that!");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.lvl_1_prefab, GetBuildPosition(), Quaternion.identity);
        if (bn) {
            turret = bn.BuffTurret(_turret, isUpgradedToLvl2, isUpgradedToLvl3);
        }
        else {
            turret = _turret;
        }

        turretBlueprint = blueprint;

        GameObject effect = Instantiate(BuildManager.build_Effect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret() {
        if (!isUpgradedToLvl2) {
            if (PlayerStats.money < turretBlueprint.upgradeToLvl_2_Cost) {
                Debug.Log("Not enought money to upgrade that!");
                return;
            }

            PlayerStats.money -= turretBlueprint.upgradeToLvl_2_Cost;
        }
        else {
            if (PlayerStats.money < turretBlueprint.upgradeToLvl_3_Cost) {
                Debug.Log("Not enought money to upgrade that!");
                return;
            }

            PlayerStats.money -= turretBlueprint.upgradeToLvl_3_Cost;
        }

        //Destroy old turret sprite
        Destroy(turret);

        //Checking if the turret is in a buff node
        BuffNode bn = GetComponent<BuffNode>();

        //Build new turret sprite
        if (!isUpgradedToLvl2) {
            GameObject _turret = Instantiate(turretBlueprint.lvl_2_prefab, GetBuildPosition(), Quaternion.identity);

            if (bn) {
                turret = bn.BuffTurret(_turret, isUpgradedToLvl2, isUpgradedToLvl3);
            }
            else {
                turret = _turret;
            }

            turret = _turret;

            GameObject effect = Instantiate(BuildManager.build_Effect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            isUpgradedToLvl2 = true;
        }
        else {
            GameObject _turret = Instantiate(turretBlueprint.lvl_3_prefab, GetBuildPosition(), Quaternion.identity);

            if (bn) {
                turret = bn.BuffTurret(_turret, isUpgradedToLvl2, isUpgradedToLvl3);
            }
            else {
                turret = _turret;
            }

            turret = _turret;

            GameObject effect = Instantiate(BuildManager.build_Effect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            isUpgradedToLvl3 = true;
        }

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret() {
        if (!isUpgradedToLvl2) {
            PlayerStats.money += turretBlueprint.GetSellPrice(turretBlueprint.cost);
        }
        else if (!isUpgradedToLvl3) {
            PlayerStats.money += turretBlueprint.GetSellPrice(turretBlueprint.upgradeToLvl_2_Cost);
        }
        else {
            PlayerStats.money += turretBlueprint.GetSellPrice(turretBlueprint.upgradeToLvl_3_Cost);
        }

        GameObject effect = Instantiate(BuildManager.sell_Effect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;

        isUpgradedToLvl2 = false;
        isUpgradedToLvl3 = false;
    }
}