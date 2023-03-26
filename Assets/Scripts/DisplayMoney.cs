using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMoney : MonoBehaviour
{
    GameObject gameController;
    private int CurrentMoney;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoney = gameController.GetComponent<Money>().money;
        text.text = CurrentMoney.ToString();
    }
}
