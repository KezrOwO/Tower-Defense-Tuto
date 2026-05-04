using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager bM;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncherTurret;

    private void Start()
    {
        bM = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        bM.SelectTurretToBudild(standardTurret); 
    }

    public void SelectMissileLauncher()
    {
        bM.SelectTurretToBudild(missileLauncherTurret);
    }
}
 