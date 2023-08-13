using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {
    [Header("Prefabs")]
    public GameObject lvl_1_prefab;
    public GameObject lvl_2_prefab;
    public GameObject lvl_3_prefab;

    [Header("Cost")]
    public int cost;
    public int upgradeToLvl_2_Cost;
    public int upgradeToLvl_3_Cost;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public int GetSellPrice(int _cost) {
        return _cost/2;
    }
}