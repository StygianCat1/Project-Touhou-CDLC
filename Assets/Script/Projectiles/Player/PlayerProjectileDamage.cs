using DefaultNamespace;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerProjectileDamage : MonoBehaviour
{
    [SerializeField] public Stats stats;
    
    [SerializeField] public float baseDamage = 10;
    [SerializeField] public float otherPotentialMultiplier = 1f;
    [SerializeField] public float totalDamage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CalculateDamage();
    }

    void CalculateDamage()
    {
        totalDamage = ((stats.power / 2) + baseDamage) * otherPotentialMultiplier;
    }
}
