using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButton : MonoBehaviour
{
    public GameObject Camera;
    public GameObject MapMenu;
    public void OnButtonPress()
    {
        Camera.GetComponent<Animator>().SetTrigger("PlayPressed");
        gameObject.GetComponent<Animator>().SetTrigger("PlayPressed");
        MapMenu.GetComponent<Animator>().SetTrigger("PlayPressed");
    }

}
