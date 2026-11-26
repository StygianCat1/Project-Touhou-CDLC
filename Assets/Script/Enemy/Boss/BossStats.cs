using System.Collections.Generic;
using Script.Enemy.Boss;
using UnityEngine;

[System.Serializable]
public class bossDropPerDeath
{
    //List of GameObject the boss drop when he loses one live
    [SerializeField] public List<GameObject> bossDropPerLife;
}


public class BossStats : MonoBehaviour
{
    //Ref to boss attack
    private BossAttack attacktype;
    
    //ref to wave script for when boss die, the wave may continue
    [SerializeField] public WaveScript waveScript;
    
    //Boss health
    [SerializeField] public float health;
    //Boss max health
    [SerializeField] public float maxHealth;
    //boss number of live
    [SerializeField][Tooltip("Put as many life as the lenght of the list of drops + 1 and vice versa")] public int nbrOfLife;
    //List of a list of Game Object that gives drop when boss loses on live
    [SerializeField] public List<bossDropPerDeath> listOfBossDropPerLife;
    
    //Speed of the boss
    [SerializeField] public float speed = 10f;
    //Path the boss may take
    [SerializeField] public EnemyPath pathToFollow;
    
    //To not call drop collectible many time
    private bool wasCalled;
    
    //Getter Setter of the boss health
    public float currentHealth
    {
        get { return health; }
        set
        {
            health = value;
            //if boss has no more health
            if (health <= 0)
            {
                //If boss has no more lives
                if (nbrOfLife <= 0)
                {
                    BossHealthUi.GetComponent<Boss_GUI>().HideUI();
                    //Destroy it and all its projectiles, drop collectables and tell wave system that the boss is defeated 
                    DestroyAllProjectiles();
                    DropCollectibleOnLifeLost();
                    waveScript.BossDefeated();
                    Destroy(gameObject);
                    return;
                }
                //If boss still has more lives, Destroy all its projectiles, drop collectables and make it change phase
                DestroyAllProjectiles();
                DropCollectibleOnLifeLost();
                nbrOfLife -= 1 ;
                attacktype.bossPatternIndex = nbrOfLife;
                attacktype.stopAttack = true;
                currentHealth = maxHealth;
                wasCalled = false;
            }
            BossHealthUi.GetComponent<Boss_GUI>().UpdateAll(currentHealth, maxHealth, nbrOfLife);
        }
    }


    private GameObject BossHealthUi;

    public GameObject bossUi
    {
        get { return BossHealthUi; }
        
        set
        {
            BossHealthUi = value;
            BossHealthUi.GetComponent<Boss_GUI>().ShowUI();
            BossHealthUi.GetComponent<Boss_GUI>().UpdateAll(currentHealth, maxHealth, nbrOfLife);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Reference the component
        attacktype = GetComponent<BossAttack>();
        bossUi = GameObject.FindGameObjectWithTag("BossHealthUI");
    }

    //Allow the wave manager to change health value
    public void ChangeHealthValue(float value)
    {
        health  = value;
        maxHealth = health;
    }

    //Drop the collectable  
    private void DropCollectibleOnLifeLost()
    {
        if (!wasCalled)
        {
            wasCalled = true;
            //Check if there's drop
            if (listOfBossDropPerLife.Count == 0)
            {
                //If no drop then skip
                return;
            }
            //Spawn all the drop in the list of collectables for this boss phase
            foreach (GameObject collectible in listOfBossDropPerLife[nbrOfLife].bossDropPerLife)
            {
                Instantiate(collectible, transform.position, Quaternion.identity);
            }
        }
    }

    
    //Destroy all the projectiles of the boss
    private void DestroyAllProjectiles()
    {
        //create an array of all the projectiles
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        //Check if not null
        if (projectiles.Length == 0)
        {
            //if null skip
            return;
        }
        //Destroy all projectile if there's some in the array
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }
}
