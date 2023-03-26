using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Text GrogName;
    public Image GrogImage;
    public GameObject Option1;
    public GameObject Option1Desc;
    public Image Option1Progress;
    public GameObject Option2;
    public GameObject Option2Desc;
    public Image Option2Progress;
    public GameObject Option3;
    public GameObject Option3Desc;
    public Image Option3Progress;
    public Sprite[] progressBars;
    public Text attackType;
    public Button leftAttackType;
    public Button rightAttackType;
    private Tower currentTower;

    private int option1Level;
    private int option2Level;
    private int option3Level;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseButton()
    {
        gameObject.GetComponent<Animator>().ResetTrigger("Clicked");
        gameObject.GetComponent<Animator>().SetTrigger("Closed");
        currentTower.visualRadius.SetActive(false);
    }
    public void OnOption1Click()
    {
        if(option1Level >= 5)
        {
            //NO NO
        }
        else if(option2Level > 0 && option3Level > 0)
        {
            //no no
        }
        else
        {
            if (option2Level > 2 || option3Level > 2)
            {
                if(option1Level < 2)
                {
                    currentTower.option1.canUpgrade();
                }
                // no no
            }
            else
            {
                currentTower.option1.canUpgrade();
            }
        }
    }
    public void OnOption2Click()
    {
        if (option2Level >= 5)
        {
            //NO NO
        }
        else if (option1Level > 0 && option3Level > 0)
        {
            //no no
        }
        else
        {
            if (option1Level > 2 || option3Level > 2)
            {
                if (option2Level < 2)
                {
                    currentTower.option2.canUpgrade();
                }
                // no no
            }
            else
            {
                currentTower.option2.canUpgrade();
            }
        }
    }
    public void OnOption3Click()
    {
        if (option3Level >= 5)
        {
            //NO NO
        }
        else if (option2Level > 0 && option1Level > 0)
        {
            //no no
        }
        else
        {
            if (option2Level > 2 || option1Level > 2)
            {
                if (option3Level < 2)
                {
                    currentTower.option3.canUpgrade();
                }
                // no no
            }
            else
            {
                currentTower.option3.canUpgrade();
            }
        }
    }
    public void UpdateMenu(Tower tower)
    {
        if(currentTower != null)
        {
            if (tower != currentTower)
            {
                currentTower.visualRadius.SetActive(false);
            }
        }
        currentTower = tower;

        GrogName.text = tower.towerName;
        GrogImage.sprite = tower.TowerSprite;

        option1Level = tower.option1.upgradeLevel;
        option2Level = tower.option2.upgradeLevel;
        option3Level = tower.option3.upgradeLevel;

        if(option1Level == 5)
        {
            Option1.GetComponentInChildren<Text>().text = tower.option1.name;
            Option2.GetComponentInChildren<Text>().text = tower.option2.name + " | $" + tower.option2.cost.ToString();
            Option3.GetComponentInChildren<Text>().text = tower.option3.name + " | $" + tower.option3.cost.ToString();
        }
        else if(option2Level == 5)
        {
            Option1.GetComponentInChildren<Text>().text = tower.option1.name + " | $" + tower.option1.cost.ToString();
            Option2.GetComponentInChildren<Text>().text = tower.option2.name;
            Option3.GetComponentInChildren<Text>().text = tower.option3.name + " | $" + tower.option3.cost.ToString();
        }
        else if(option3Level == 5)
        {
            Option1.GetComponentInChildren<Text>().text = tower.option1.name + " | $" + tower.option1.cost.ToString();
            Option2.GetComponentInChildren<Text>().text = tower.option2.name + " | $" + tower.option2.cost.ToString();
            Option3.GetComponentInChildren<Text>().text = tower.option3.name;
        }
        else
        {
            Option1.GetComponentInChildren<Text>().text = tower.option1.name +" | $" + tower.option1.cost.ToString();
            Option2.GetComponentInChildren<Text>().text = tower.option2.name +" | $" + tower.option2.cost.ToString();
            Option3.GetComponentInChildren<Text>().text = tower.option3.name +" | $" + tower.option3.cost.ToString();
        }
        
        Option1Desc.GetComponent<Text>().text = tower.option1.description;
        Option1Progress.sprite = progressBars[tower.option1.upgradeLevel];

        
        Option2Desc.GetComponent<Text>().text = tower.option2.description;
        Option2Progress.sprite = progressBars[tower.option2.upgradeLevel];

        
        Option3Desc.GetComponent<Text>().text = tower.option3.description;
        Option3Progress.sprite = progressBars[tower.option3.upgradeLevel];

        if(tower.attackMode==0)
        {
            attackType.text = "Last";
        }
        else if (tower.attackMode== 1)
        {
            attackType.text = "First";
        }
        else if (tower.attackMode== 2)
        {
            attackType.text = "Strongest";
        }
    }
    public void OnLeftAttack()
    {
        if (currentTower.attackMode == 0)
        {
            currentTower.attackMode = 2;
        }
        else
        {
            currentTower.attackMode -= 1;
        }
        UpdateMenu(currentTower);
    }
    public void OnRightAttack()
    {
        if (currentTower.attackMode == 2)
        {
            currentTower.attackMode = 0;
        }
        else
        {
            currentTower.attackMode += 1;
        }
        UpdateMenu(currentTower);
    }

}
