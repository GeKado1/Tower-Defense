using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notEnoughtMoneyColor;
    [SerializeField] private Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

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

        if (!buildManager.HasMoney) {
            rend.material.color = notEnoughtMoneyColor;
        }
        else {
            rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }

    private void OnMouseDown() {
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

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint) {
        if (PlayerStats.money < blueprint.cost) {
            Debug.Log("Not enought money to build that!");
            return;
        }

        PlayerStats.money = PlayerStats.money - blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(BuildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret() {
        if (PlayerStats.money < turretBlueprint.upgradeCost) {
            Debug.Log("Not enought money to upgrade that!");
            return;
        }

        PlayerStats.money = PlayerStats.money - turretBlueprint.upgradeCost;

        //Destroy old turret sprite
        Destroy(turret);

        //Build new turret sprite
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(BuildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret() {
        Debug.Log(isUpgraded);
        if (!isUpgraded) {
            PlayerStats.money = PlayerStats.money + turretBlueprint.GetSellPrice(turretBlueprint.cost);
        }
        else {
            PlayerStats.money = PlayerStats.money + turretBlueprint.GetSellPrice(turretBlueprint.upgradeCost);
        }

        Destroy(turret);
        turretBlueprint = null;
    }
}