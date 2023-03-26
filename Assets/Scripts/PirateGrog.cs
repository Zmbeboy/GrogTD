using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateGrog : MonoBehaviour
{
    public Tower tower;
    public GameObject UpgradeMenu;

    private void Awake()
    {
        tower = gameObject.GetComponent<Tower>();
        tower.option1 = new Option("Buccaneering", "Grog Learns to be a cool buccaneer and attacks faster!", 0, 100);
        tower.option2 = new Option("Buccaneering", "Grog Learns to be a cool buccaneer and attacks faster!", 0, 100);
        tower.option3 = new Option("Buccaneering", "Grog Learns to be a cool buccaneer and attacks faster!", 0, 100);
        //tower.option2 = new Option("Flying Dutchman", "Arrgh he will send you to davy jones!", 0, 1);
        //tower.option3 = new Option("Johnny Depp", "Johnny Depp", 0, 1);
        UpgradeMenu = GameObject.Find("UpgradeMenu");
    }
    private void Update()
    {
        if(tower.option1.upgraded == true)
        {
            if(tower.option1.name == "Buccaneering")
            {
                tower.TowerAttackSpeedUpdate(0.75f);
                tower.option1 = new Option("Observation Haki", "Grog learns to control his haki and uses it to detect camouflaged enemies.", 1, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option1.name == "Observation Haki")
            {
                tower.camo = true;
                tower.option1 = new Option("Armament Haki", "Grog uses haki to punch straight through metal! With some extra damage...", 2, 1000);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option1.name == "Armament Haki")
            {
                tower.damage += 2;
                tower.metal = true;
                tower.option1 = new Option("Rubber Smoothie", "Grog drinks the Rubber Smoothie, massively increasing his Damage and Attack Speed!", 3, 3200);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option1.name == "Rubber Smoothie")
            {
                tower.damage += 3;
                tower.attackSpeed /= 2;
                tower.option1 = new Option("King of Pirates", "Grog becomes the one king of the pirates!", 4, 800);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option1.name == "King of Pirates")
            {
                tower.damage += 3;
                tower.attackSpeed /= 2;
                tower.option1 = new Option("Grog is the King of Pirates.", "", 5, 0);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
        }


        if (tower.option2.upgraded == true)
        {
            if (tower.option2.name == "Buccaneering")
            {
                tower.TowerAttackSpeedUpdate(0.75f);
                tower.option2 = new Option("Observation Haki", "Grog learns to control his haki and uses it to detect camouflaged enemies.", 1, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option2.name == "Observation Haki")
            {
                tower.camo = true;
                tower.option2 = new Option("First Mate", "Grog moves up in the crew and gains a larger attack radius", 2, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option2.name == "First Mate")
            {
                tower.TowerRangeUpdate(1.2f);
                tower.option2 = new Option("King of Pirates", "Grog becomes the one king of the pirates!", 3, 800);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
        }


        if (tower.option3.upgraded == true)
        {
            if (tower.option3.name == "Buccaneering")
            {
                tower.TowerAttackSpeedUpdate(0.75f);
                tower.option3 = new Option("Observation Haki", "Grog learns to control his haki and uses it to detect camouflaged enemies.", 1, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option3.name == "Observation Haki")
            {
                tower.camo = true;
                tower.option3 = new Option("First Mate", "Grog moves up in the crew and gains a larger attack radius", 2, 300);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
            else if (tower.option3.name == "First Mate")
            {
                tower.TowerRangeUpdate(1.2f);
                tower.option3 = new Option("King of Pirates", "Grog becomes the one king of the pirates!", 3, 800);
                UpgradeMenu.GetComponent<UpgradeMenu>().UpdateMenu(tower);
            }
        }
    }
}
