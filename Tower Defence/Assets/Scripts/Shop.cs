using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    public int standardCost = 100;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret selected");
        standardTurret.Cost = 100;
        standardTurret.UpgradeCost = standardTurret.Cost * 2;
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectAnotherTurret()
    {
        Debug.Log("Another Turret selected");
        anotherTurret.Cost = 200;
        anotherTurret.UpgradeCost = anotherTurret.Cost * 2;
        buildManager.SelectTurretToBuild(anotherTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected");
        missileLauncher.Cost = 500;
        missileLauncher.UpgradeCost = missileLauncher.Cost * 2;
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected");
        laserBeamer.Cost = 750;
        laserBeamer.UpgradeCost = laserBeamer.Cost * 2;
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
