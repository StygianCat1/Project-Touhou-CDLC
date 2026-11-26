using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Script.Player;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Ref to Shoot script
    private Shoot _shootRef;
    //Ref to Bomb script
    private Bomb _bombRef; 
    //Ref to armor equipment capacity script
    private EquipementArmorProtetion _equipementArmorProtetionRef;
    //ref to GUI
    private GameObject gUI;
    
    //Getter Setter of Game UI
    public GameObject gameUI
    {
        get { return gUI; }
        set
        {
            //Update value of GUi at spawn
            gUI = value;
            gUI.GetComponent<Score_GUI>().UpdateAllScores(score, hiScore);
            gUI.GetComponent<PlayerInfo_GUI>().UpdateAllInfos(health, bomb);
            gUI.GetComponent<PlayerStats_GUI>().UpdateAllStats(power,140, graze, points);
        }
    }

    //ref of the choice of the kit
    public KitChoosed kit;
    
    //getter Setter for the kit chosed
    public KitChoosed kitchoosed
    {
        get{ return kit;}
        set
        {
            //Set kit chosen also in bomb & shot
            kit = value;
            _shootRef.characterKit = value;
            _bombRef.characterKit = value;
        }
    }
    
    //Ref to the current score
    [SerializeField] public int currentScore = 0;
    //ref to the current hiscore
    [SerializeField] public int hiScore;

    //Getter Setter for score
    public int score
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            //Update value in GUI
            gUI.GetComponent<Score_GUI>().ChangeScore(score);
            //If the score is higher than the high score
            if (currentScore > hiScore)
            {
                //Set high score to score and update in GUI
                hiScore = currentScore;
                gUI.GetComponent<Score_GUI>().ChangeHiScore(hiScore);
            }
        }
    }
    
    //Ref to current health
    [SerializeField] public int currentHealth = 3;
    //Time of invulnerability
    [SerializeField] public float invulnerabilityTime = 3f;
    //Ref to the core collider
    [SerializeField] public CharacterCoreCollision coreCollider ;
    //Ref to the mesh renderer (character body)
    [SerializeField] public MeshRenderer charaBodyRenderer;
    //Ref to current bomb
    [SerializeField] public int currentBomb = 3;
    //Ref to number of continue
    [SerializeField] public int continueNbr = 3;
    
    //Ref to the continue UI
    [SerializeField] public GameObject continueUi;
    //ref to the fade to Black UI
    [SerializeField] public GameObject fadeToBlack;

    //Getter Setter to character health
    public int health
    {
        get
        {
            return currentHealth;
        }
        set 
        {
            //if the value is inferior
            if (value < currentHealth)
            {
                //Check for if equipment ability activate 
                if (_equipementArmorProtetionRef.isActiveAndEnabled && _equipementArmorProtetionRef.CheckIfTakeDamage())
                {
                    //if it does, stop damage 
                    return;
                }
                //Set invincible as damage taken
                InvincibilityTime();
                Invoke(nameof(MakeRespawnToBeginPos), 0.1f);
            }
            //if the value is equal or superior
            else if (!(value < currentHealth))
            {
                //Set to true, to stop Lose power bug
                losePowerCheck = true;
            }
            
            //If number of health change, update it in the UI
            currentHealth = Mathf.Clamp(value, 0, 8);
            gUI.GetComponent<PlayerInfo_GUI>().UpdateHealth(health);
            
            //If health is negative
            if (health <= 0)
            {
                //if the number of continue
                if (continueNbr == 0)
                {
                    //Transition and go back to main menu 
                    fadeToBlack.SetActive(true);
                    fadeToBlack.GetComponent<FadeToBlack>().levelName = "MainMenuScene";
                    return;
                }
                //Stop lose power and set continue UI to active
                losePowerCheck = true;
                continueUi.SetActive(true);
                Invoke(nameof(MakeRespawnToBeginPos), 0.1f);
                return;
            }
            //Lose power on take damage
            LosePower();
            losePowerCheck = false;
        }
    }
    
    //Getter Setter to character bomb
    public int bomb
    {
        get
        {
            return currentBomb;
        }
        set
        {
            //If number of bomb change, update it in the UI
            currentBomb = Mathf.Clamp(value, 0, 8);
            gUI.GetComponent<PlayerInfo_GUI>().UpdateBomb(bomb);
        }
    }

    //Ref to the power
    [SerializeField] public int powerNbr = 8;
    //List of GameObject / Collectable to drop on take damage
    [SerializeField] public List<GameObject> powerDropOnDamage;
    //List of GameObject / Collectable to drop on death
    [SerializeField] public List<GameObject> powerDropOnDeath;
    
    //Ref to the graze
    [SerializeField] public int grazeNbr = 0;
    //Ref to the point
    [SerializeField] public int pointsNbr = 0;
    
    //Getter Setter of power
    public int power
    {
        get
        {
            return powerNbr;
        }
        set
        {
            //If number of power change, update it in the UI
            powerNbr = Mathf.Clamp(value, 0, 140);
            gUI.GetComponent<PlayerStats_GUI>().UpdatePower(power, 140);
        }
    }
    
    //Getter Setter of graze
    public int graze
    {
        get
        {
            return grazeNbr;
        }
        set
        {
            //If number of graze change, update it in the UI
            grazeNbr = value;
            gUI.GetComponent<PlayerStats_GUI>().UpdateGraze(graze);
        }
    }

    //Getter Setter of point
    public int points
    {
        get
        {
            return pointsNbr;
        }
        set
        {
            //If number of point change, update it in the UI
            pointsNbr = value;
            gUI.GetComponent<PlayerStats_GUI>().UpdatePoints(points);
        }
    }

    //Timer for the invulnerability
    private float invulnerabilityTimer;
    //Check for when lose power
    private bool losePowerCheck;
    //Get begin position to teleport character there when damage taken
    private Vector3 beginPos;

    private void Start()
    {
        //Reference the component
        _shootRef = GetComponent<Shoot>();
        _bombRef = GetComponent<Bomb>(); 
        _equipementArmorProtetionRef = GetComponent<EquipementArmorProtetion>();
        continueUi.GetComponent<Continue>().stats = this;
        //reference the GameObject
        gameUI = GameObject.FindGameObjectWithTag("GUI");
        beginPos = transform.position;
    }

    //Responsible for time invincible / invulnerable
    private void InvincibilityTime()
    {
        //Tell collider that invulnerable
        coreCollider.invulnerable = true;
        //Show invulnerability
        ShowInvincibility();
        Invoke(nameof(StopInvincibility), invulnerabilityTime);
    }

    //Show the character invulnerability
    private void ShowInvincibility()
    {
        //If still invulnerable
        if (invulnerabilityTimer <= invulnerabilityTime)
        {
            //toggle on and off body visibility
            charaBodyRenderer.enabled = !charaBodyRenderer.isVisible;
            //Add to timer and call back the show invincibility
            invulnerabilityTimer += 0.2f;
            Invoke(nameof(ShowInvincibility), 0.2f);
            return;
        }
        //When invincibility end, sreset timer & toggle on body visibility
        invulnerabilityTimer = 0;
        charaBodyRenderer.enabled = true;
    }

    //Stop the character invulnerability
    private void StopInvincibility()
    {
        coreCollider.invulnerable = false;
    }

    //Lose power on take damage
    private void LosePower()
    {
        //Check if has to lose some power
        if (losePowerCheck)
        {
            return;
        }

        //Add some score and lose power 
        score += 10000;
        power = power - (13 + Mathf.RoundToInt(power * 0.1f));
        //For all collectables in the loop
        foreach (GameObject powerDrop in powerDropOnDamage)
        {
            //Spawn them a bit higher than the character for him not to get them on spawn
            Instantiate(powerDrop, transform.position + new Vector3(0,0,5), transform.rotation);
        }
    }

    //Spawn the continue collectables
    public void SpawnContinueCollectible()
    {
        //Reset the score
        score = 0;
        //For all collectables in the loop
        foreach (GameObject powerDrop in powerDropOnDeath)
        {
            //Spawn them a bit higher than the character for him not to get them on spawn
            Instantiate(powerDrop, transform.position + new Vector3(0,0,5), transform.rotation);
        }
    }

    private void MakeRespawnToBeginPos()
    {
        transform.position = beginPos;
    }
}
