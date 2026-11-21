using System.Collections;
using System.Collections.Generic;
using Script.Misc;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class Enemy
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public int enemyHealth;

    public void Start()
    {
        if (enemyPrefab.GetComponent<EnemyStats>() != null)
        {
            enemyPrefab.GetComponent<EnemyStats>().health = enemyHealth;
        }
    }
}

[System.Serializable]
public class WaveRound
{
    [SerializeField] public WaveType waveType;
    [SerializeField] public List<Enemy> wave;
    [SerializeField] public int timeBetweenWaves;
}


public class WaveScript : MonoBehaviour
{
    
    [SerializeField] public List<WaveRound> waveRounds;
    [SerializeField] public float timeBetweenEnemies = 0.8f;

    private int waveIndex = 0;
    private int security = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BeginWave();
    }


    private void BeginWave()
    {
        StartCoroutine(SpawnWave());

        if (waveRounds[waveIndex].waveType == WaveType.NormalEnemy)
        {
            if (waveRounds[waveIndex + 1].waveType == WaveType.NormalEnemy)
            {
                //print("trying invoke");
                Invoke( nameof(BeginWave), waveRounds[waveIndex].timeBetweenWaves +  (waveRounds[waveIndex].wave.Count * timeBetweenEnemies));
                 
                waveIndex += 1;
            }
            else
            { 
                Invoke(nameof (CheckForBoss),waveRounds[waveIndex].wave.Count * timeBetweenEnemies);
            }
        }
        else
        {
            waveIndex += 1;
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveRounds[waveIndex].wave.Count; i++)
        {
            //print(i + "hello" + waveIndex);
            
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }


    private void CheckForBoss()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemiesProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        if (enemies.Length == 0 && enemiesProjectiles .Length == 0  && collectibles .Length == 0)
        {
            //print("spawnBoss");
            //make boss spawn 
            return;
        }
        if (security <= 8)
        {
            Invoke(nameof(CheckForBoss), 1);
            security += 1;
        }
        else
        {
            //print("spawnBoss");
            //make boss spawn
        }
    }
}
