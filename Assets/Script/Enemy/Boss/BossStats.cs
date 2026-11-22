using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class bossDropPerDeath
{
    [SerializeField] public List<GameObject> bossDropPerLife;
}



public class BossStats : MonoBehaviour
{
    [SerializeField] public WaveScript waveScript;
    
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField][Range(1,5)][Tooltip("Put as many life as the lenght of the list of drops and vice versa")] public int nbrOfLife;
    [SerializeField] public List<bossDropPerDeath> listOfBossDropPerLife;
    
    [SerializeField] public float speed = 10f;
    [SerializeField] public EnemyPath pathToFollow;
    
    
    public float currentHealth
    {
        get { return health; }
        set
        {
            if (health <= 0)
            {
                if (nbrOfLife < 0)
                {
                    DestroyAllProjectiles();
                    DropCollectibleOnLifeLost();
                    waveScript.BossDefeated();
                    return;
                }

                DestroyAllProjectiles();
                DropCollectibleOnLifeLost();
                nbrOfLife -= 1 ;
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    public void ChangeHealthValue(float value)
    {
        health  = value;
        maxHealth = health;
    }

    private void DropCollectibleOnLifeLost()
    {
        foreach (GameObject collectible in listOfBossDropPerLife[nbrOfLife - 1].bossDropPerLife)
        {
            Instantiate(collectible, transform.position, Quaternion.identity);
        }
    }

    private void DestroyAllProjectiles()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }
}
