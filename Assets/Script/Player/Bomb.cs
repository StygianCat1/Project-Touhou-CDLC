using System;
using Script.Player;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Stats _stats;
    private PlayerMouvement _playerMouvement;
    private float currentTimeStop = 0;
    private bool timeStopped = false;
    
    //[HideInInspector] 
    [SerializeField] public KitChoosed characterKit;
    [SerializeField] public float timeStopDuration = 3f;
    [SerializeField] public float timeRewind = 3f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _stats = GetComponent<Stats>();
        _playerMouvement = GetComponent<PlayerMouvement>();
    }

    private void Update()
    {
        if (timeStopped)
        {
            TimerBombCapacity1();
        }
    }
    

    public void BombExplosion()
    {
        GameObject[] allCollectibles = GameObject.FindGameObjectsWithTag("Collectible");
        if (_stats.bomb >= 1)
        {
            ExplosionCapacity(allCollectibles);
            if (characterKit == KitChoosed.FirstKit)
            {
                BombCapacity1();
            }
            else
            {
                BombCapacity2();
            }
            print("bomb explode once :)");
            _stats.bomb -= 1;
        }
    }


    private void ExplosionCapacity(GameObject[] collectibleArray)
    {
        for (int i = 0; i < collectibleArray.Length; i++)
        {
            collectibleArray[i].GetComponent<CollectibleMouvement>().MoveTowardPlayer();
        }
        //Script to destroy all bullets
    }
    
    
    private void BombCapacity1()
    {
        _playerMouvement.timePaused = true;
        Time.timeScale = 0;
        timeStopped = true;
    }
    
    private void TimerBombCapacity1()
    {
        if (currentTimeStop >= timeStopDuration)
        {
            currentTimeStop = 0;
            timeStopped = false;
            TimeStopEnd();
        }
        currentTimeStop += Time.unscaledDeltaTime;
    }

    private void TimeStopEnd()
    {
        Time.timeScale = 1;
        print("time stop ended");
    }
    
    private void BombCapacity2()
    {
        
    }
}
