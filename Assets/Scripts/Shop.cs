using UnityEngine;

public class Shop : MonoBehaviour {
    BuildManager buildManager;

    [SerializeField] private TurretBlueprint standardTurret;
    [SerializeField] private TurretBlueprint missileLauncher;
    [SerializeField] private TurretBlueprint laserBeamer;
    [SerializeField] private TurretBlueprint gatlingTurret;
    [SerializeField] private TurretBlueprint balistaTurret;

    // Start is called before the first frame update
    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer() {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void SelectGatlingTurret() {
        Debug.Log("Gatling Turret Selected");
        buildManager.SelectTurretToBuild(gatlingTurret);
    }

    public void SelectBalistaTurret() {
        Debug.Log("Balista Turret Selected");
        buildManager.SelectTurretToBuild(balistaTurret);
    }
}