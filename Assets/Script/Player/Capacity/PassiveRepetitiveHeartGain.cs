using Script.Player.Capacity.Enum;
using UnityEngine;

public class PassiveRepetitiveHeartGain : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.PassiveMultipleUse;
    [SerializeField] public int healCapacity = 1;

    private void Start()
    {
        stats = GetComponent<Stats>();
        Giveheal();
    }

    public void Giveheal()
    {
        stats.health += healCapacity;
    }
}
