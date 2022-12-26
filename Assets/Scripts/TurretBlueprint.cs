using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {
    [Header("Prefabs")]
    public GameObject prefab;
    public GameObject upgradedPrefab;

    [Header("Cost")]
    public int cost;
    public int upgradeCost;

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