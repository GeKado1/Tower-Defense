using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour {
    private Node target;

    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private Button upgradeButton;

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
            upgradeCostText.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else {
            upgradeCostText.text = "MAXED";
            upgradeButton.interactable = false;
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
}