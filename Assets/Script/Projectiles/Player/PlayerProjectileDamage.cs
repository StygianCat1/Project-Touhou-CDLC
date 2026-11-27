using DefaultNamespace;
using UnityEngine;

public class PlayerProjectileDamage : MonoBehaviour
{
    //Ref to character Stats
    [SerializeField] public Stats stats;
    
    //Base damage of the projectile
    [SerializeField] public float baseDamage = 10;
    //Any other multiplier of damage
    [SerializeField] public float otherPotentialMultiplier = 1f;
    //The total of the damage
    [SerializeField] public float totalDamage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set directly the damage that the GameObjct will deal
        CalculateDamage();
    }

    void CalculateDamage()
    {
        //Calculate the total of the damage
        totalDamage = (stats.power / 10 + baseDamage) * otherPotentialMultiplier;
    }
}
