using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayRound : MonoBehaviour
{
    public GameObject roundStarter;
    private Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    { 
        text.text ="Round: " +roundStarter.GetComponent<WaveSpawn>().currentRound.ToString() + "/" + roundStarter.GetComponent<WaveSpawn>().rounds.Count.ToString();
    }

}
