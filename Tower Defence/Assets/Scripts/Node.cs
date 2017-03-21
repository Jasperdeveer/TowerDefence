using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{


    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionOffSet;

    private Renderer rend;

    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }



    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.Cost)
        {
            Debug.Log("Not enough to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.Cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left is " + PlayerStats.Money);
    }

    public void upgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.UpgradeCost)
        {
            Debug.Log("Not enough to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.UpgradeCost;
        
        // delete the old turret
        Destroy(turret);

        // build the upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret upgraded! Money left is " + PlayerStats.Money);
    }

        public void SellTurret(){
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }


    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


}
