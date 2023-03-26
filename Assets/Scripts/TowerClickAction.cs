using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClickAction : MonoBehaviour
{
    private GameObject UpgradeMenu;
    private void Awake()
    {
        UpgradeMenu = GameObject.Find("UpgradeMenu");
    }

    /*private void OnMouseDown()
    {
            ObjectClicked(gameObject);
           
    }
    private void OnTouchStart()
    {
        ObjectClicked(gameObject);
        GetComponentInParent<Tower>().visualRadius.SetActive(true);
        var niceColor = Color.white;
        niceColor.a = .5f;
        GetComponentInParent<Tower>().visualRadius.GetComponent<SpriteRenderer>().color = niceColor;
    }*/ //secret mobile texture
    public void ObjectClicked()
    {
        GetComponentInParent<Tower>().visualRadius.SetActive(true);
        var niceColor = Color.white;
        niceColor.a = .5f;
        GetComponentInParent<Tower>().visualRadius.GetComponent<SpriteRenderer>().color = niceColor;

        UpgradeMenu.GetComponent<Animator>().SetTrigger("Clicked");
        UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(GetComponentInParent<Tower>());
    }
}
