using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCost : MonoBehaviour
{
    public GameObject dropper;
    private int CurrentMoney;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }
    void Update()
    {
        text.text = dropper.GetComponent<DropTowerType>().towerCost.ToString();
    }
}
