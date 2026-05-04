using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    public GameObject turret;
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

    private void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if (!bM.canBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Déjà une tourelle");
            return;
        }


        bM.BuildTurretOn(this);
       
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
