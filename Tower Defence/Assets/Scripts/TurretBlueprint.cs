using UnityEngine;

[System.Serializable] // makes it visible in the inspector for unity
public class TurretBlueprint
{

    public GameObject prefab;
    private int cost = 0;
    public int Cost
    {
        get { return this.cost; }
        set { this.cost = value; }
    }

    public GameObject upgradedPrefab;
    private int upgradeCost;
    public int UpgradeCost
    {
        get { return this.upgradeCost; }
        set { this.upgradeCost = value; }
    }


    public int GetSellAmount()
    {
        return Cost / 2;
    }

    public int GetTowerCost()
    {
        return Cost;
    }

}
