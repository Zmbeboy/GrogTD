using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public List<GameObject> Enemies;
    public GameObject furthestEnemy;
    public GameObject lastEnemy;
    public GameObject StrongestEnemy;
    public bool attacking;

    public bool camo;
    public bool ignoreDamageResist;
    public bool metal;
    public bool pierce;
    public bool magic;
    public bool explosive;
    private bool timeSlow;

    //bool hasattackModes for things like tack shooters which dont turn
    public int attackMode;
    private bool CanAttack;
    public float attackSpeed;
    public string towerName;
    public Option option1;
    public Option option2;
    public Option option3;
    public Sprite TowerSprite;
    public GameObject visualRadius;

    // Start is called before the first frame update
    private void Awake()
    {
        timeSlow = false;
        attackMode = 1;
        CanAttack = true;
    }

    // Update is called once per frame
    private void Update()
    {
        int numOfTimeEnemies = 0;
        foreach(GameObject enemy in Enemies)
        {
            if(enemy.GetComponent<Enemy>().time)
            {
                numOfTimeEnemies++;
                if(!timeSlow)
                {
                    attackSpeed *= 2;
                    timeSlow = true;
                }
            }
        }
        if(numOfTimeEnemies == 0)
        {
            if (timeSlow)
            {
                attackSpeed /= 2;
                timeSlow = false;
            }
        }
    }

    public void TowerRangeUpdate(float multiplier)
    {
        gameObject.GetComponent<CircleCollider2D>().radius *= multiplier;
        visualRadius.transform.localScale *= multiplier;
        visualRadius.transform.localScale.z.Equals(1);
    }

    public void TowerAttackSpeedUpdate(float multiplier)
    {
        attackSpeed *= multiplier;
    }

    IEnumerator TargetChoose(float time)
    {
        if (attackMode == 0)
        {
            shoot(lastEnemy);
        }
        else if(attackMode == 1)
        {
            shoot(furthestEnemy);
        }
        else if(attackMode == 2)
        {
            shoot(StrongestEnemy);
        }

        yield return new WaitForSeconds(time);

        attacking = false;
        CanAttack = true;
    }

    //this function should be rewritten to be more modular for each tower
    //keep the turning for most towers but things like planes and nonturning towers shouldnt have this
    void shoot(GameObject target)
    {
        
        Vector3 Diff = (target.transform.position - transform.position);
        float angle = Mathf.Atan2(Diff.y, Diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        target.GetComponent<Enemy>().damageSlime(this);
    }

    public void shootNoTurn(GameObject target)
    {
        target.GetComponent<Enemy>().damageSlime(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (camo)
            {
                Enemies.Add(collision.gameObject);
            }
            else
            {
                if(!collision.gameObject.GetComponent<Enemy>().camo)
                {
                    Enemies.Add(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            if (camo)
            {
                furthestEnemy = Enemies[0];
                foreach (GameObject enemy in Enemies)
                {
                    if (enemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled > furthestEnemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled)
                    {
                        furthestEnemy = enemy;
                    }
                }
                lastEnemy = Enemies[0];
                foreach (GameObject enemy in Enemies)
                {
                    if (enemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled < furthestEnemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled)
                    {
                        lastEnemy = enemy;
                    }
                }
                StrongestEnemy = Enemies[0];
                foreach (GameObject enemy in Enemies)
                {
                    if (enemy.GetComponent<Enemy>().strengthLevel > StrongestEnemy.GetComponent<Enemy>().strengthLevel)
                    {
                        StrongestEnemy = enemy;
                    }
                }
                if (CanAttack)
                {
                    CanAttack = false;
                    attacking = true;
                    StartCoroutine(TargetChoose(attackSpeed));
                }
            }
            else
            {
                if (!collision.gameObject.GetComponent<Enemy>().camo)
                {
                    furthestEnemy = Enemies[0];
                    foreach (GameObject enemy in Enemies)
                    {
                        if (enemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled > furthestEnemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled)
                        {
                            furthestEnemy = enemy;
                        }
                    }
                    lastEnemy = Enemies[0];
                    foreach (GameObject enemy in Enemies)
                    {
                        if (enemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled < furthestEnemy.GetComponentInParent<PathCreation.Examples.PathFollower>().distanceTravelled)
                        {
                            lastEnemy = enemy;
                        }
                    }
                    StrongestEnemy = Enemies[0];
                    foreach (GameObject enemy in Enemies)
                    {
                        if (enemy.GetComponent<Enemy>().strengthLevel > StrongestEnemy.GetComponent<Enemy>().strengthLevel)
                        {
                            StrongestEnemy = enemy;
                        }
                    }
                    if (CanAttack)
                    {
                        attacking = true;
                        CanAttack = false;
                        StartCoroutine(TargetChoose(attackSpeed));
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Enemies.Contains(collision.gameObject))
        {
            Enemies.Remove(collision.gameObject);
        }
    }
    
}
