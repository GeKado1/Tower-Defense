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
        #if UNITY_EDITOR
            Debug.Log("Standard Turret Selected");
        #endif

        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher() {
        #if UNITY_EDITOR
            Debug.Log("Missile Launcher Selected");
        #endif

        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer() {
        #if UNITY_EDITOR
            Debug.Log("Laser Beamer Selected");
        #endif
        
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void SelectGatlingTurret() {
        #if UNITY_EDITOR
            Debug.Log("Gatling Turret Selected");
        #endif

        buildManager.SelectTurretToBuild(gatlingTurret);
    }

    public void SelectBalistaTurret() {
        #if UNITY_EDITOR
            Debug.Log("Balista Turret Selected");
        #endif

        buildManager.SelectTurretToBuild(balistaTurret);
    }
}