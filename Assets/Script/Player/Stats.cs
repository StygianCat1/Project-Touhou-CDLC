using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Script.Player;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private Shoot _shootRef;
    private Bomb _bombRef; 
    private EquipementArmorProtetion _equipementArmorProtetionRef;
    private GameObject gUI;
    public GameObject gameUI
    {
        get { return gUI; }
        set
        {
            gUI = value;
            //gUI.GetComponent<DifficultyChoosen_GUI>();
            //gUI.GetComponent<Score_GUI>();
            gUI.GetComponent<PlayerInfo_GUI>().UpdateAllInfos(health, bomb);
            gUI.GetComponent<PlayerStats_GUI>().UpdateAllStats(power,140, graze, points);
            //gUI.GetComponent<Capacity_GUI>();
        }
    }

    public KitChoosed kit;
    public KitChoosed kitchoosed
    {
        get{ return kit;}
        set
        {
            kit = value;
            _shootRef.characterKit = value;
            _bombRef.characterKit = value;
        }
    }

    [SerializeField] public int currentScore = 0;
    [SerializeField] public int hilScore;
    
    [SerializeField] public int currentHealth = 3;
    [SerializeField] public float invulnerabilityTime = 3f;
    [SerializeField] public CharacterCoreCollision coreCollider ;
    [SerializeField] public MeshRenderer charaBodyRenderer;
    [SerializeField] public int currentBomb = 3;
    [SerializeField] public int continueNbr = 3;
    
    [SerializeField] public GameObject continueUi;
    [SerializeField] public GameObject fadeToBlack;

    public int health
    {
        get
        {
            return currentHealth;
        }
        set 
        {
            if (value < currentHealth)
            {
                if (_equipementArmorProtetionRef.isActiveAndEnabled && _equipementArmorProtetionRef.CheckIfTakeDamage())
                {
                    return;
                }
                InvincibilityTime();
            }
            
            currentHealth = Mathf.Clamp(value, 0, 8);
            gUI.GetComponent<PlayerInfo_GUI>().UpdateHealth(health);
            
            if (health <= 0)
            {
                if (continueNbr == 0)
                {
                    fadeToBlack.SetActive(true);
                    fadeToBlack.GetComponent<FadeToBlack>().levelName = "MainMenuScene";
                    return;
                }
                death = true;
                continueUi.SetActive(true);
                return;
            }
            LosePower();
            death = false;
        }
    }

    public int bomb
    {
        get
        {
            return currentBomb;
        }
        set
        {
            currentBomb = Mathf.Clamp(value, 0, 8);
            gUI.GetComponent<PlayerInfo_GUI>().UpdateBomb(bomb);
        }
    }

    [SerializeField] public int powerNbr = 8;
    [SerializeField] public List<GameObject> powerDropOnDamage;
    [SerializeField] public List<GameObject> powerDropOnDeath;
    
    [SerializeField] public int grazeNbr = 0;
    [SerializeField] public int pointsNbr = 0;

    public int power
    {
        get
        {
            return powerNbr;
        }
        set
        {
            powerNbr = Mathf.Clamp(value, 0, 140);
            gUI.GetComponent<PlayerStats_GUI>().UpdatePower(power, 140);
        }
    }
    
    public int graze
    {
        get
        {
            return grazeNbr;
        }
        set
        {
            grazeNbr = value;
            gUI.GetComponent<PlayerStats_GUI>().UpdateGraze(graze);
        }
    }

    public int points
    {
        get
        {
            return pointsNbr;
        }
        set
        {
            pointsNbr = value;
            gUI.GetComponent<PlayerStats_GUI>().UpdatePoints(points);
        }
    }


    private float invulnerabilityTimer;
    private bool death;

    private void Start()
    {
        _shootRef = GetComponent<Shoot>();
        _bombRef = GetComponent<Bomb>(); 
        _equipementArmorProtetionRef = GetComponent<EquipementArmorProtetion>();
        gameUI = GameObject.FindGameObjectWithTag("GUI");
        continueUi.GetComponent<Continue>().stats = this;
    }

    private void InvincibilityTime()
    {
        coreCollider.invulnerable = true;
        ShowInvincibility();
        Invoke(nameof(StopInvincibility), invulnerabilityTime);
    }

    private void ShowInvincibility()
    {
        if (invulnerabilityTimer <= invulnerabilityTime)
        {
            charaBodyRenderer.enabled = !charaBodyRenderer.isVisible;
            invulnerabilityTimer += 0.2f;
            Invoke(nameof(ShowInvincibility), 0.2f);
            return;
        }
        invulnerabilityTimer = 0;
        charaBodyRenderer.enabled = true;
    }

    private void StopInvincibility()
    {
        coreCollider.invulnerable = false;
    }

    private void LosePower()
    {
        if (death)
        {
            return;
        }
        power = power - (13 + Mathf.RoundToInt(power * 0.1f));
        foreach (GameObject powerDrop in powerDropOnDamage)
        {
            Instantiate(powerDrop, transform.position + new Vector3(0,0,5), transform.rotation);
        }
    }

    public void SpawnContinueCollectible()
    {
        foreach (GameObject powerDrop in powerDropOnDeath)
        {
            Instantiate(powerDrop, transform.position + new Vector3(0,0,5), transform.rotation);
        }
    }
}
