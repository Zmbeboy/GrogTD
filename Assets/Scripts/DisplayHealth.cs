using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    GameObject gameController;
    private int CurrentHealth;
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
        CurrentHealth = gameController.GetComponent<LifeManager>().Health;
        text.text = CurrentHealth.ToString();
    }
}
