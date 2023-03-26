using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughMoney : MonoBehaviour
{
    public GameObject CostText;
    public GameObject Dropper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dropper.GetComponent<DropTowerType>().canBuy)
        {
            gameObject.GetComponent<Image>().color = Color.red;
            CostText.GetComponent<Text>().color = Color.red;
            Dropper.GetComponent<RawImage>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
            CostText.GetComponent<Text>().color = Color.white;
            Dropper.GetComponent<RawImage>().color = Color.white;
        }
    }
}
