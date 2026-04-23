using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private GameObject turret;
    private Renderer rend;

    public Vector3 positionOffset;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Déjà une tourelle");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret =  Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
       
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
