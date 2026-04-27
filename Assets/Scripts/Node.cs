using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private GameObject turret;
    private Renderer rend;

    public Vector3 positionOffset;

    private BuildManager bM;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        bM = BuildManager.instance;
    }

    private void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if (bM.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("Déjà une tourelle");
            return;
        }


        GameObject turretToBuild = bM.GetTurretToBuild();
        turret =  Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
       
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return; 

        if (bM.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
