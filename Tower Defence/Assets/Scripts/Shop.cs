using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectAnotherTurret()
    {
        Debug.Log("Another Turret selected");
        buildManager.SelectTurretToBuild(anotherTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
