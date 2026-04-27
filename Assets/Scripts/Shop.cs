using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager bM;

    private void Start()
    {
        bM = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        bM.SetTurretToBudild(bM.standardTurretPrefab);
    }
}
