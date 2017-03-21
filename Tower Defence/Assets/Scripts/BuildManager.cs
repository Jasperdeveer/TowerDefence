using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this; // make sure there's only one BuildManager

    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } } //prohibity, only allows to GET something.
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.Cost; } } // check if player has enough money.


    public void selectNode (Node node){

if (selectedNode == node)
{
    DeselectNode();
    return;
}

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild(){
        return turretToBuild;
    }
}
