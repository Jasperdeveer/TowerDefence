﻿using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour {

	public GameObject ui;

	public Text upgradeCost;
public Text sellAmount;

	public Button upgradeButton; 

	private Node target;

	public void SetTarget(Node _target){
		target = _target;

		transform.position = target.GetBuildPosition(); // build on top of the node

		if (!target.isUpgraded)
		{
			upgradeCost.text = "€" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		}
		else{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "€" + target.turretBlueprint.GetSellAmount();

		ui.SetActive(true);
	}

	public void Hide (){
		ui.SetActive(false);
	}

	public void Upgrade(){
		target.upgradeTurret();
		BuildManager.instance.DeselectNode();
	}

		public void Sell(){
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}

}
