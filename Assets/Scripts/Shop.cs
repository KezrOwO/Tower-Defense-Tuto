using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager bM;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncherTurret;
    public TurretBlueprint laserBeamerTurret;

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

    public void SelectLaserBeamer()
    {
        bM.SelectTurretToBudild(laserBeamerTurret);
    }
}
 