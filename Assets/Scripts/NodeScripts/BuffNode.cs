using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Node))]
public class BuffNode : MonoBehaviour {
    private float actualRange;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void BuffTurret(TurretBlueprint turretBlueprint, bool isLvl2, bool isLvl3) {
        float buff;

        if (!isLvl3) {
            actualRange = turretBlueprint.lvl_3_prefab.GetComponent<Turret>().GetRange();
            buff = actualRange * 0.25f;
            turretBlueprint.lvl_3_prefab.GetComponent<Turret>().SetRange(actualRange + buff);
        }
        else if (!isLvl2) {
            actualRange = turretBlueprint.lvl_2_prefab.GetComponent<Turret>().GetRange();
            buff = actualRange * 0.2f;
            turretBlueprint.lvl_2_prefab.GetComponent<Turret>().SetRange(actualRange + buff);
        }
        else {
            actualRange = turretBlueprint.lvl_1_prefab.GetComponent<Turret>().GetRange();
            buff = actualRange * 0.1f;
            turretBlueprint.lvl_1_prefab.GetComponent<Turret>().SetRange(actualRange + buff);
        }

        Debug.Log("TurretBuffed");
    }

    public void ReturnTurretNormalRange(TurretBlueprint turretBlueprint, bool isLvl2, bool isLvl3, float range) {
        if (!isLvl3) {
            turretBlueprint.lvl_3_prefab.GetComponent<Turret>().SetRange(range);
        }
        else if (!isLvl2) {
            turretBlueprint.lvl_2_prefab.GetComponent<Turret>().SetRange(range);
        }
        else {
            turretBlueprint.lvl_1_prefab.GetComponent<Turret>().SetRange(range);
        }
    }
}