using Script.Player.Capacity.Enum;
using UnityEngine;

public class PassiveRepetitiveBombGain : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.PassiveMultipleUse;
    [SerializeField] public int bombCapacity = 1;

    private void Start()
    {
        stats = GetComponent<Stats>();
        Givebomb();
    }

    public void Givebomb()
    {
        stats.bomb += bombCapacity;
    }
}
