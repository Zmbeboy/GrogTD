using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGlobalRecognition : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("GameController").GetComponent<EnemyTracker>().activeEnemies.Add(gameObject);
    }
    public void whenPopped()
    {
        GameObject.Find("GameController").GetComponent<EnemyTracker>().activeEnemies.Remove(gameObject);
    }
}
