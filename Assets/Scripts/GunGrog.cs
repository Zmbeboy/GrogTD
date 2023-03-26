using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGrog : MonoBehaviour
{
    private Tower tower;
    private GameObject UpgradeMenu;
    private bool shotgun;

    private void Awake()
    {
        shotgun = false;
        tower = gameObject.GetComponent<Tower>();
        tower.option1 = new Option("ShotGun Grog", "Low Range firing but bullets spread!", 0, 500);
        tower.option2 = new Option("Machine Gun Grog", "Faster firing, pew pew pew", 0, 1);
        tower.option3 = new Option("John Grog", "He does that keanu reeves thing", 0, 1);
        UpgradeMenu = GameObject.Find("UpgradeMenu");
    }
    private void Update()
    {
        //attacking animation
        if(tower.attacking == true)
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("Shooting",true);
            if (shotgun)
            {
                //how to do shotgun splitting
                /*foreach (GameObject enemy in tower.Enemies)
                {
                    if (tower.attackMode == 0)
                    {
                        if (enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled <= tower.lastEnemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled + 0.75 && enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled <= tower.lastEnemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled - 0.75)
                        {
                            tower.shootNoTurn(enemy);
                        }
                    }
                    else if (tower.attackMode == 1)
                    {
                        if (enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled <= tower.furthestEnemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled + 0.75 && enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled <= tower.furthestEnemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled - 0.75)
                        {
                            tower.shootNoTurn(enemy);
                        }
                    }
                    else if (tower.attackMode == 2)
                    {
                        if (enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled <= tower.StrongestEnemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled + 0.75 && enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled <= tower.StrongestEnemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled - 0.75)
                        {
                            tower.shootNoTurn(enemy);
                        }
                    }
                }*/
            }
        }
        else if(tower.attacking == false)
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("Shooting",false);
        }

        //upgrade logic
        if (tower.option1.upgraded == true)
        {
            if (tower.option1.name == "ShotGun Grog")
            {
                shotgun = true;            
                gameObject.GetComponentInChildren<Animator>().SetTrigger("Shotgun");
                tower.TowerRangeUpdate(0.5f);
                tower.option1 = new Option("Observation Haki", "Grog learns to control his haki and uses it to detect camouflaged enemies.", 1, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
        }

        if (tower.option3.upgraded == true)
        {
            if (tower.option3.name == "John Grog")
            {
                tower.TowerAttackSpeedUpdate(0.5f);
                //make him go akimbo
                tower.option3 = new Option("John Grog 2", "Grog gets a sequel.", 1, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option3.name == "John Grog 2")
            {
                tower.TowerRangeUpdate(1.2f);
                //make him do something idk
                tower.option3 = new Option("John Grog 3: Parabellum", "John Grog rides a horse in this one", 2, 800); //make him ride a horse in this one
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
        }
    }
}
