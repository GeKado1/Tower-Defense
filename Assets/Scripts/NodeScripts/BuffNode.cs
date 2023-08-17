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

    public GameObject BuffTurret(GameObject turret, bool isLvl2, bool isLvl3) {
        float buff;
        actualRange = turret.GetComponent<Turret>().GetRange();

        if (!isLvl3) {
            buff = actualRange * 0.25f;
        }
        else if (!isLvl2){
            buff = actualRange * 0.2f;
        }
        else {
            buff = actualRange * 0.1f;
        }

        turret.GetComponent<Turret>().SetRange(actualRange + buff);

        return turret;
    }
}