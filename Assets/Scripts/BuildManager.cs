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

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBudild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
