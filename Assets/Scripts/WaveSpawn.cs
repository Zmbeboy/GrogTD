using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public List<Round> rounds;
    public int currentRound = 0;
    public bool canSpawn;
    private List<GameObject> baddies;
    private bool moneyClaimed;
    //public GameObject EnemyPreFab;

    private void Awake()
    {
        baddies = new List<GameObject>();
    }
    private void Update()
    {
        if(GameObject.Find("GameController").GetComponent<EnemyTracker>().activeEnemies.Count == 0 && baddies.Count == 0)
        {
            if (currentRound != 0 && !moneyClaimed)
            {
                GameObject.Find("GameController").GetComponent<Money>().money += rounds[currentRound - 1].CashOnRoundEnd;
                moneyClaimed = true;
            }
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }
    }
    public void nextRound()
    {
        if (canSpawn)
        {
            spawnWave(rounds[currentRound]);
            currentRound++;
            moneyClaimed = false;
        }
    }
    void spawnWave(Round round)
    {
        for(int i = 0;  i < round.enemies.Count;i++)
        {
            baddies.Add(round.enemies[i]);
        }
        StartCoroutine(spawnEnemy(round.delay, baddies));
    }
    IEnumerator spawnEnemy(float time,List<GameObject> enemies)
    {
        yield return new WaitForSeconds(time);

        Instantiate(enemies[0]);
        enemies.RemoveAt(0);
        if (enemies.Count > 0)
        {
            StartCoroutine(spawnEnemy(time, enemies));
        }
    }
}
