using System;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb : MonoBehaviour
{
    private Stats _stats;
    private PlayerMouvement _playerMouvement;
    private PlayerInput _playerInput;
    private float currentTimeStop = 0;
    private bool timeStopped = false;
    private bool timeIsreversing = false;
    private List<PlayerState> _playerStates = new List<PlayerState>();
    
    //[HideInInspector] 
    [SerializeField] public KitChoosed characterKit;
    [SerializeField] public float timeStopDuration = 3f;
    [SerializeField] public float timeRewindDuration = 5f;
    [SerializeField] public float bombProjectileDestructionRange = 8f;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _stats = GetComponent<Stats>();
        _playerMouvement = GetComponent<PlayerMouvement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (timeIsreversing)
        {
            ReverseTime();
        }
        else
        {
            RecordState();    
        }
        
        if (timeStopped)
        {
            TimerBombCapacity1();
        }
    }
    

    public void BombExplosion()
    {
        GameObject[] allCollectibles = GameObject.FindGameObjectsWithTag("Collectible");
        GameObject[] allEnemyProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        if (_stats.bomb >= 1)
        {
            ExplosionCapacity(allCollectibles, allEnemyProjectiles);
            if (characterKit == KitChoosed.FirstKit)
            {
                BombCapacity1();
            }
            else
            {
                BombCapacity2();
            }
            _stats.bomb -= 1;
        }
    }


    private void ExplosionCapacity(GameObject[] collectibleArray, GameObject[] enemyProjectilArray)
    {
        for (int i = 0; i < collectibleArray.Length; i++)
        {
            collectibleArray[i].GetComponent<CollectibleMouvement>().MoveTowardPlayer();
        }

        for (int i = 0; i < enemyProjectilArray.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemyProjectilArray[i].transform.position) <= bombProjectileDestructionRange)
            {
                Destroy(enemyProjectilArray[i]);
            }
            else
            {
                print("projectile too far");
            }
        }
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
    }
    
    private void BombCapacity2()
    {
        timeIsreversing = !timeIsreversing;
    }

    private void RecordState()
    {
        if (_playerStates.Count > Mathf.Round(timeRewindDuration / Time.fixedDeltaTime))
        {
            _playerStates.RemoveAt(_playerStates.Count - 1);
        }
        _playerStates.Insert(0, new PlayerState(transform.position, _stats.health));
    }

    private void ReverseTime()
    {
        if (_playerStates.Count > 0)
        {
            _playerInput.enabled = false;
            PlayerState playerState = _playerStates[0];
            transform.position = playerState.position;
            _stats.health = playerState.health;
            
            _playerStates.RemoveAt(0);
        }
        else
        {
            _playerInput.enabled = true;
            timeIsreversing = false;
        }
    }

    [System.Serializable]
    public class PlayerState
    {
        public Vector3 position;
        public int health;

        public PlayerState(Vector3 pos, int h)
        {
            position = pos;
            health = h;
        }
    }
}
