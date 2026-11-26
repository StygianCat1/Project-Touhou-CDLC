using System.Collections;
using System.Collections.Generic;
using System.IO;
using Script.Misc;
using Unity.VisualScripting;
using UnityEngine;



//New class that store a GameObject & a health variable that act as an enemy Ref 
[System.Serializable]
public class Enemy
{
    //Ref GameObject to enemyPrefab
    [SerializeField] public GameObject enemyPrefab;
    
    //int health that tell how much health the enemy will have
    [SerializeField] public int enemyHealth = 100;
}


//New class that will allow to manipulate how the wave will work
[System.Serializable]
public class WaveRound
{
    //Enum to see what type of wave it is, be it basic enemy or boss
    [SerializeField] public WaveType waveType;

    //List of the Enemy class, to know what to spawn 
    [SerializeField] public List<Enemy> wave;

    //The path that the enemy will take
    [SerializeField] public EnemyPath path;

    //An int that is used to control the time before next wave
    [SerializeField] public int timeBetweenWaves;
}

public class WaveScript : MonoBehaviour
{
    //List to allow many wave to succeed, taken from WaveRound Class
    [SerializeField] public List<WaveRound> waveRounds;
    //An int that tell how many seconds the wave have to wait before spawning a new enemy (time between enemy spawn)
    [SerializeField] public float timeBetweenEnemies = 0.8f;
    //Ref of the satge lenght to be used for the boss
    [SerializeField] public StageLenght stageLenghtRefForBosses;
    
    //Ref to scoreboard UI (to spawn at the end of the game
    [SerializeField] public GameObject ScoreboardRef;

    //Private int to keep track of the waveRound list index
    private int waveIndex = 0;
    //Private int to keep track of the enemy at each wave
    private int enemyIndex = 0 ;
    //An int to have as security for any kind of check
    private int security = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BeginWave();
    }


    private void BeginWave()
    {
        //if it was the last wave of the list
        if (waveRounds.Count - 1 <= waveIndex)
        {
            //Spawn the scoreboard
            ScoreboardRef.SetActive(true);
            return;
        }
        
        //index of enemy to keep in check
        enemyIndex = 0;
        //Start coroutine to spawn the enemy
        StartCoroutine(SpawnWave());
        //If the next wave is a normal enemy wave
        if (waveRounds[waveIndex+1].waveType == WaveType.NormalEnemy)
        {
            //Call the begin wave function after sometime
            Invoke(nameof(BeginWave), waveRounds[waveIndex].timeBetweenWaves +  (waveRounds[waveIndex].wave.Count * timeBetweenEnemies));
        }
        //If the next wave is a boss wave then 
        else if (waveRounds[waveIndex+1].waveType == WaveType.Boss)
        {
            //Call the check for boss function after sometime
            Invoke(nameof(CheckForBoss), waveRounds[waveIndex].timeBetweenWaves +  (waveRounds[waveIndex].wave.Count * timeBetweenEnemies));
        }
    }

    //Enumerator that will spawn enemy by wave
    private IEnumerator SpawnWave()
    {
        //Check for index empty
        if (waveRounds[waveIndex].wave.Count == 0)
        {
            print("wave" + waveIndex + " is empty");
            //if empty then go to next wave
            waveIndex += 1;
            yield break;
        }
        //if enemy have a path
        if (waveRounds[waveIndex].path != null)
        {
            //Get number of enemy
            for (int i = 0; i < waveRounds[waveIndex].wave.Count; i++)
            {
                //Spawn enemy on path position & give it reference (path & health) 
                GameObject enemyRef = Instantiate(waveRounds[waveIndex].wave[enemyIndex].enemyPrefab, waveRounds[waveIndex].path.waypoints[0].transform.position, waveRounds[waveIndex].path.waypoints[0].transform.rotation);
                EnemyStats stats = enemyRef.GetComponent<EnemyStats>();
                stats.pathToFollow = waveRounds[waveIndex].path;
                stats.ChangeHealthValue(waveRounds[waveIndex].wave[enemyIndex].enemyHealth);
                //add to enemy index
                enemyIndex += 1;
                //Wait some time for next enemy to spawn
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            //Add to wave index
            waveIndex += 1;
        }
    }


    private void CheckForBoss()
    {
        //Set enemy index back to 0 in case
        enemyIndex = 0;
        //Get references for all enemies, enemies projectiles & collectables
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemiesProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        //If there's none
        if (enemies.Length == 0 && enemiesProjectiles .Length == 0  && collectibles .Length == 0)
        {
            //Spawn the boss & give it reference (path, health, stage lenght)
            GameObject boss = Instantiate(waveRounds[waveIndex].wave[enemyIndex].enemyPrefab, waveRounds[waveIndex].path.waypoints[0].transform.position, waveRounds[waveIndex].path.waypoints[0].transform.rotation);
            BossStats stats = boss.GetComponent<BossStats>();
            stats.pathToFollow = waveRounds[waveIndex].path;
            stats.ChangeHealthValue(waveRounds[waveIndex].wave[enemyIndex].enemyHealth);
            stats.waveScript = this;
            BossAttack attack = boss.GetComponent<BossAttack>();
            attack.stageLenght = stageLenghtRefForBosses;
            return;
        }
        //Check for security purpose to not get into a infinite loop
        if (security <= 8)
        {
            //Check again after 1 sce
            Invoke(nameof(CheckForBoss), 1);
            security += 1;
        }
        //If after 8 sec it does not work
        else
        {
            //Delete all element (enemies, enemies projectiles & collectables 
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            foreach (GameObject enemyprojectile in enemiesProjectiles)
            {
                Destroy(enemyprojectile);
            }
            foreach (GameObject collectible in collectibles)
            {
                Destroy(collectible);
            }
            //Spawn the boss & give it reference (path, health, stage lenght)
            GameObject boss = Instantiate(waveRounds[waveIndex].wave[enemyIndex].enemyPrefab, waveRounds[waveIndex].path.waypoints[0].transform.position, waveRounds[waveIndex].path.waypoints[0].transform.rotation);
            BossStats stats = boss.GetComponent<BossStats>();
            stats.pathToFollow = waveRounds[waveIndex].path;
            stats.ChangeHealthValue(waveRounds[waveIndex].wave[enemyIndex].enemyHealth);
            stats.waveScript = this;
            BossAttack attack = boss.GetComponent<BossAttack>();
            attack.stageLenght = stageLenghtRefForBosses;
        }
    }
    
    
    //Function for when boss is defeated to call it and continue in the wave
    public void BossDefeated()
    {
        print("boss defeated");
        waveIndex += 2;
        Invoke(nameof(BeginWave), 3);
    }
}
