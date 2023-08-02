using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour {
    private Node target;

    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private TextMeshProUGUI sellPriceText;

    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;

    public GameObject ui;

    // Start is called before the first frame update
    void Start() {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetTarget(Node targetNode) {
        target = targetNode;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded) {
            upgradeCostText.text = "$" + target.turretBlueprint.upgradeToLvl_2_Cost;
            upgradeButton.interactable = true;

            sellPriceText.text = "$" + target.turretBlueprint.GetSellPrice(target.turretBlueprint.cost);
        }
        else {
            upgradeCostText.text = "MAXED";
            upgradeButton.interactable = false;

            sellPriceText.text = "$" + target.turretBlueprint.GetSellPrice(target.turretBlueprint.upgradeToLvl_2_Cost);
        }

        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}