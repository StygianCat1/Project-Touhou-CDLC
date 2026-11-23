using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Script.Player;
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
    [SerializeField] public float invulnerabilityTime = 2f;
    [SerializeField] public int currentBomb = 3;
    [SerializeField] public int continueNbr = 3;

    public int health
    {
        get
        {
            return currentHealth;
        }
        set 
        {
            if (value < currentHealth && _equipementArmorProtetionRef.isActiveAndEnabled)
            {
                if (_equipementArmorProtetionRef.CheckIfTakeDamage())
                {
                    return;
                }
            }
            currentHealth = Mathf.Clamp(value, 0, 8);
            gUI.GetComponent<PlayerInfo_GUI>().UpdateHealth(health);
            if (health <= 0)
            {
                // script to make character explode and ask if want to continue
            }
            else
            {
                LosePower();
            }
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

    private void Start()
    {
        _shootRef = GetComponent<Shoot>();
        _bombRef = GetComponent<Bomb>(); 
        _equipementArmorProtetionRef = GetComponent<EquipementArmorProtetion>();
        gameUI = GameObject.FindGameObjectWithTag("GUI");
    }

    public void UseBomb()
    {
        bomb -= 1;
    }

    public void GainBomb()
    {
        bomb += 1;
    }

    public void GainPower(int powerGain)
    {
        power += powerGain;
    }

    public void LosePower()
    {
        //power -= Mathf.RoundToInt(power * 0.9f); 
    }
}
