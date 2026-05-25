using UnityEditor.Experimental.GraphView;
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
    private Renderer rend;

    public Vector3 positionOffset;

    private BuildManager bM;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        bM = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset; 
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("pas assez d'argent pour améliorer la tourelle");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(bM.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;

        Debug.Log("Tourelle amélioré");
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("pas assez d'argent pour ça");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(bM.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
        Debug.Log("Tourelle construite");
    }

    private void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject())
            return;

        

        if (turret != null)
        {
            bM.SelectNode(this);
            return;
        }

        if (!bM.canBuild)
            return;

        BuildTurret(bM.GetTurretBlueprint());
       
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return; 

        if (!bM.canBuild)
            return;

        if (bM.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
