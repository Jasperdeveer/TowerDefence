using UnityEngine.UI;
using UnityEngine;

public class TowerCostUI : MonoBehaviour {

	public Text towerCost;
	Shop shopCost;


	void Awake()
	{
		towerCost.text = shopCost.standardCost.ToString();
	}
}
