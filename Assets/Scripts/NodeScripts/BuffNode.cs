using UnityEngine;

[RequireComponent(typeof(Node))]
public class BuffNode : MonoBehaviour {
    public GameObject BuffTurret(GameObject turret, bool isLvl2, bool isLvl3) {
        Turret turretScript = turret.GetComponent<Turret>();

        float rangeBuff;
        float actualRange = turretScript.GetRange();

        float fireRateBuff = 0f;
        float actualFireRate = turretScript.GetFireRate();

        bool isLaser = turretScript.isLaserTurret();
        int DoTBuff = 0;
        int actualDoT = turretScript.GetDoT();

        //Checking the Turret Level for apply different buffs
        if (!isLvl3) {
            rangeBuff = actualRange * 0.25f;

            if (!isLaser) {
                fireRateBuff = 0.3f;
            }
            else {
                DoTBuff = 2;
            }
            
        }
        else if (!isLvl2){
            rangeBuff = actualRange * 0.2f;

            if (!isLaser) {
                fireRateBuff = 0.2f;
            }
            else {
                DoTBuff = 2;
            }
        }
        else {
            rangeBuff = actualRange * 0.1f;

            if (!isLaser) {
                fireRateBuff = 0.1f;
            }
            else {
                DoTBuff = 2;
            }
        }

        //Applying node buffs
        turretScript.SetRange(actualRange + rangeBuff);
        if (!isLaser) {
            turretScript.SetFireRate(actualFireRate + fireRateBuff);
        }
        else {
            turretScript.SetDot(actualDoT + DoTBuff);
        }

        return turret;
    }
}