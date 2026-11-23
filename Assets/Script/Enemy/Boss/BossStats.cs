using System.Collections.Generic;
using Script.Enemy.Boss;
using UnityEngine;

[System.Serializable]
public class bossDropPerDeath
{
    [SerializeField] public List<GameObject> bossDropPerLife;
}



public class BossStats : MonoBehaviour
{
    private BossAttack attacktype;
    
    [SerializeField] public WaveScript waveScript;
    
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField][Tooltip("Put as many life as the lenght of the list of drops + 1 and vice versa")] public int nbrOfLife;
    [SerializeField] public List<bossDropPerDeath> listOfBossDropPerLife;
    
    [SerializeField] public float speed = 10f;
    [SerializeField] public EnemyPath pathToFollow;
    
    
    public float currentHealth
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                print("change lifeNbr");
                if (nbrOfLife <= 0)
                {
                    DestroyAllProjectiles();
                    DropCollectibleOnLifeLost();
                    waveScript.BossDefeated();
                    Destroy(gameObject);
                    return;
                }
                DestroyAllProjectiles();
                DropCollectibleOnLifeLost();
                nbrOfLife -= 1 ;
                attacktype.bossPatternIndex = nbrOfLife;
                attacktype.stopAttack = true;
                currentHealth = maxHealth;
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        attacktype = GetComponent<BossAttack>();
    }

    public void ChangeHealthValue(float value)
    {
        health  = value;
        maxHealth = health;
    }

    private void DropCollectibleOnLifeLost()
    {
        if (listOfBossDropPerLife.Count == 0)
        {
            return;
        }
        foreach (GameObject collectible in listOfBossDropPerLife[nbrOfLife].bossDropPerLife)
        {
            Instantiate(collectible, transform.position, Quaternion.identity);
        }
    }

    private void DestroyAllProjectiles()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        if (projectiles.Length == 0)
        {
            return;
        }
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }
}
