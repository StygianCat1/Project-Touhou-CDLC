using System;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb : MonoBehaviour
{
    //Ref to character stats
    private Stats _stats;
    //Ref to movement
    private PlayerMouvement _playerMouvement;
    //ref to player input
    private PlayerInput _playerInput;
    
    //Kit chosen in Stats
    [SerializeField] public KitChoosed characterKit;
    //Duration of the time stop ability
    [SerializeField] public float timeStopDuration = 3f;
    //Duration of the time rewind ability
    [SerializeField] public float timeRewindDuration = 5f;
    //Ref to the core collider
    [SerializeField] public Collider coreCollider;
    //Ref to the body collider
    [SerializeField] public Collider bodyCollider;
    //Range of the bomb destruction
    [SerializeField] public float bombProjectileDestructionRange = 8f;
    
    //Current time stop timer
    private float currentTimeStop;
    //Bool to check if time is stopped
    private bool timeStopped; 
    //Bool to check if time is reversing
    private bool timeIsreversing; 
    
    //State of the character, pos and health for time rewind
    private List<PlayerState> _playerStates = new List<PlayerState>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Reference the component
        _stats = GetComponent<Stats>();
        _playerMouvement = GetComponent<PlayerMouvement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //Check if time is reversing
        if (timeIsreversing)
        {
            //Play timer reverse
            ReverseTime();
        }
        else
        {
            //Record the character pos and health otherwise
            RecordState();    
        }
        
        //Check if time is stopped
        if (timeStopped)
        {
            //Launch timer for time stop duration
            TimerBombCapacity1();
        }
    }
    

    public void BombExplosion()
    {
        //List of all the collectables
        GameObject[] allCollectibles = GameObject.FindGameObjectsWithTag("Collectible");
        //List of all the enemy projectile
        GameObject[] allEnemyProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        //Check if has bomb
        if (_stats.bomb >= 1)
        {
            //Use bomb
            ExplosionCapacity(allCollectibles, allEnemyProjectiles);
            //Check which kit is used and use capacity of the kit
            if (characterKit == KitChoosed.FirstKit)
            {
                //Time stop
                BombCapacity1();
            }
            else
            {
                //Time rewind
                BombCapacity2();
            }
            //remove one bomb
            _stats.bomb -= 1;
        }
    }


    //Bomb
    private void ExplosionCapacity(GameObject[] collectibleArray, GameObject[] enemyProjectilArray)
    {
        //For all collectable in scene
        for (int i = 0; i < collectibleArray.Length; i++)
        {
            //Make collectables goes toward player
            collectibleArray[i].GetComponent<CollectibleMouvement>().MoveTowardPlayer();
        }

        //For all enemy projectile in scene
        for (int i = 0; i < enemyProjectilArray.Length; i++)
        {
            //If projectiles are closed to player position
            if (Vector3.Distance(transform.position, enemyProjectilArray[i].transform.position) <= bombProjectileDestructionRange)
            {
                //Destroy them
                Destroy(enemyProjectilArray[i]);
            }
        }
    }
    
    
    //Time freeze capacity
    private void BombCapacity1()
    {
        //Tell player movement that time is stopped
        _playerMouvement.timePaused = true;
        //Stop time
        Time.timeScale = 0;
        timeStopped = true;
    }
    
    //Timer for time stop
    private void TimerBombCapacity1()
    {
        //If timer find its duration
        if (currentTimeStop >= timeStopDuration)
        {
            //End the time stop 
            TimeStopEnd();
        }
        //Timer in unscale time as time is paused
        currentTimeStop += Time.unscaledDeltaTime;
    }

    //End the time stop
    private void TimeStopEnd()
    {
        currentTimeStop = 0;
        timeStopped = false;
        Time.timeScale = 1;
    }
    
    
    //Activate tire rewind / record
    private void BombCapacity2()
    {
        timeIsreversing = !timeIsreversing;
    }
    
    //record each second the pos and health of the character 
    private void RecordState()
    {
        //If number of record too high
        if (_playerStates.Count > Mathf.Round(timeRewindDuration / Time.fixedDeltaTime))
        {
            //Remove the more ancient 
            _playerStates.RemoveAt(_playerStates.Count - 1);
        }
        //Add a new record
        _playerStates.Insert(0, new PlayerState(transform.position, _stats.health));
    }

    //reverse the time
    private void ReverseTime()
    {
        //If has records
        if (_playerStates.Count > 0)
        {
            //Set collider and inputs to off
            bodyCollider.enabled = false;
            coreCollider.enabled = false;
            _playerInput.enabled = false;
            //Reverse the pos and health with record
            PlayerState playerState = _playerStates[0];
            transform.position = playerState.position;
            _stats.health = playerState.health;
            //remove used record
            _playerStates.RemoveAt(0);
        }
        else
        {
            //Set collider and inputs to on
            _playerInput.enabled = true;
            bodyCollider.enabled = true;
            coreCollider.enabled = true;
            //Time is reversing is now false and record abck
            timeIsreversing = false;
        }
    }

    [System.Serializable]
    public class PlayerState
    {
        //State of the player position
        public Vector3 position;
        //State of the player health
        public int health;

        //Ref to it's class to use in record
        public PlayerState(Vector3 pos, int h)
        {
            position = pos;
            health = h;
        }
    }
}
