using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecontroller : MonoBehaviour
{
    public float timeControl = 1f;
    private GameObject slidery;
    // Start is called before the first frame update
    void Start()
    {
        slidery = GameObject.Find("TimeSlider");
    }

    // Update is called once per frame
    void Update()
    {
        timeControl = slidery.GetComponent<Slider>().value;
        Time.timeScale = timeControl;
    }

    public void ChangeTimeValue()
    {

    }
}
