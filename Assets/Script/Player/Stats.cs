using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] public int currentScore = 0;
    [SerializeField] public int hilScore;
    
    [SerializeField] public int currentHealth = 3;
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
            currentHealth = Mathf.Clamp(value, 0, 8);
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
        }
    }

    [SerializeField] public int powerNbr = 0;
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
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            // script to make character explode and ask if want to continue
        }
        else
        {
            LosePower();
        }
    }

    public void Heal()
    {
        health += 1;
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
        power = power - Mathf.RoundToInt(power * 0.9f); 
    }
}
