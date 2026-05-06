using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;
    private void Awake()
    {
        if(instance!= null)
        {
            Debug.LogError("Il y a deja un BuildManager");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool canBuild { get { return turretToBuild != null;  } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {

        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("pas assez d'argent pour ça");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret =  Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
        Debug.Log(PlayerStats.money);
    }

    public void SelectTurretToBudild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }


}
