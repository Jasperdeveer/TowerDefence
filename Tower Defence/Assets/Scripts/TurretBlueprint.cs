using UnityEngine;

[System.Serializable] // makes it visible in the inspector for unity
public class TurretBlueprint{

	public GameObject prefab;
	public int cost;  

	public GameObject upgradedPrefab;
	public int upgradeCost;  
	

public int GetSellAmount(){
	return cost /2;
}

public int GetTowerCost(){
	return cost;
}

}
