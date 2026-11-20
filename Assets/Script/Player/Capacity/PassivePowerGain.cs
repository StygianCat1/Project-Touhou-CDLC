using Script.Player.Capacity.Enum;
using UnityEngine;

public class PassivePowerGain : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.PassiveSingleUse;
    [SerializeField] public int powerCapacity = 40;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void GivePower()
    {
        stats.power += powerCapacity;
    }
}
