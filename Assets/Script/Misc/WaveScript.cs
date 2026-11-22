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
        if (waveRounds.Count - 1 <= waveIndex)
        {
            print("it was the last wave");
            print("spawn score & end game");
            return;
        }
        
        enemyIndex = 0;
        StartCoroutine(SpawnWave());
        if (waveRounds[waveIndex+1].waveType == WaveType.NormalEnemy)
        {
            Invoke(nameof(BeginWave), waveRounds[waveIndex].timeBetweenWaves +  (waveRounds[waveIndex].wave.Count * timeBetweenEnemies));
        }
        else if (waveRounds[waveIndex+1].waveType == WaveType.Boss)
        {
            print("spawn boss through normal mean");
            Invoke(nameof(CheckForBoss), waveRounds[waveIndex].timeBetweenWaves +  (waveRounds[waveIndex].wave.Count * timeBetweenEnemies));
        }
    }

    //Enumerator that will spawn enemy by wave
    private IEnumerator SpawnWave()
    {
        if (waveRounds[waveIndex].wave.Count == 0)
        {
            print("wave" + waveIndex + " is empty");
            waveIndex += 1;
            yield break;
        }
        if (waveRounds[waveIndex].path != null)
        {
            for (int i = 0; i < waveRounds[waveIndex].wave.Count; i++)
            {
                GameObject enemyRef = Instantiate(waveRounds[waveIndex].wave[enemyIndex].enemyPrefab, waveRounds[waveIndex].path.waypoints[0].transform.position, waveRounds[waveIndex].path.waypoints[0].transform.rotation);
                EnemyStats stats = enemyRef.GetComponent<EnemyStats>();
                stats.pathToFollow = waveRounds[waveIndex].path;
                stats.ChangeHealthValue(waveRounds[waveIndex].wave[enemyIndex].enemyHealth);
                enemyIndex += 1;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            waveIndex += 1;
        }
    }


    private void CheckForBoss()
    {
        print("is checking for boss");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemiesProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        if (enemies.Length == 0 && enemiesProjectiles .Length == 0  && collectibles .Length == 0)
        {
            enemyIndex = 0;
            GameObject boss = Instantiate(waveRounds[waveIndex].wave[enemyIndex].enemyPrefab, waveRounds[waveIndex].path.waypoints[0].transform.position, waveRounds[waveIndex].path.waypoints[0].transform.rotation);
            BossStats stats = boss.GetComponent<BossStats>();
            stats.pathToFollow = waveRounds[waveIndex].path;
            stats.ChangeHealthValue(waveRounds[waveIndex].wave[enemyIndex].enemyHealth);
            stats.waveScript = this;
            return;
        }
        if (security <= 8)
        {
            Invoke(nameof(CheckForBoss), 1);
            security += 1;
        }
        else
        {
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
            GameObject boss = Instantiate(waveRounds[waveIndex].wave[enemyIndex].enemyPrefab, transform.position, transform.rotation);
            BossStats stats = boss.GetComponent<BossStats>();
            stats.pathToFollow = waveRounds[waveIndex].path;
            stats.ChangeHealthValue(waveRounds[waveIndex].wave[enemyIndex].enemyHealth);
            stats.waveScript = this;print("spawn boss");
            //BossDefeated();
        }
    }
    
    
    public void BossDefeated()
    {
        print("boss defeated");
        waveIndex += 2;
        Invoke(nameof(BeginWave), 3);
    }
}
