using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponentInParent<LifeManager>().Health = gameObject.GetComponentInParent<LifeManager>().Health - collision.gameObject.GetComponent<Enemy>().EnemyDamage;
        }
    }
}
