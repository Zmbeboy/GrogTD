using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyDamage;
    public int numOfLayers;
    public int moneyPerPop;
    public int strengthLevel;
    public bool camo;
    public bool damageResist;
    public bool metal;
    public bool pierceResist;
    public bool magicResist;
    public bool explosiveResist;
    public bool time;

    public List<GameObject> ChildEnemy;
    private GameObject gameController;
    // Start is called before the first frame update
    private void Awake()
    {
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfLayers <= 0)
        {
            popSlime();
        }
    }
    void popSlime()
    {
        for(int i = 0; i < ChildEnemy.Count;i++)
        {
            if (ChildEnemy[i] != null)
            {

                CreateChildren(ChildEnemy[i],i);
            }
        }
        GameObject.Find("explosion").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("explosion").GetComponent<AudioSource>().clip);
        gameObject.GetComponentInParent<enemyGlobalRecognition>().whenPopped();
        gameController.GetComponent<Money>().money += moneyPerPop;
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void damageSlime(Tower attackingTower)
    {
        int towerDamage = attackingTower.damage;
        if (camo)
        {
            if (attackingTower.camo)
            { 
                //you good.
            }
            else
            {
                towerDamage = 0;
            }
        }
        if(metal)
        {
            if (attackingTower.metal)
            {
                //you good.
            }
            else
            {
                towerDamage = 0;
            }
        }

        numOfLayers -= towerDamage;
        //calculate here
    }


    void CreateChildren(GameObject childEnemy, float distanceDelay)
    {
        GameObject enemy = Instantiate(childEnemy);
        enemy.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreation.PathCreator>();
        enemy.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled = gameObject.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled-(distanceDelay/2.5f);
        if (numOfLayers < 0)
        {
            enemy.GetComponentInChildren<Enemy>().numOfLayers += this.numOfLayers;
        }
    }


}
 