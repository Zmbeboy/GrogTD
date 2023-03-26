using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option
{
    public string name;
    public string description;
    public int upgradeLevel;
    public int cost;
    public bool upgraded = false;

    public Option(string name, string description, int upgradeLevel, int cost)
    {
        this.name = name;
        this.description = description;
        this.upgradeLevel = upgradeLevel;
        this.cost = cost;
    }

    public void canUpgrade()
    {
        if (GameObject.Find("GameController").GetComponent<Money>().money >= cost)
        {
            GameObject.Find("GameController").GetComponent<Money>().money -= cost;
            upgraded = true;
        }
    }
    
    //make a "canUpgrade" function to lock after 3 in one tier are upgraded also with money
}
