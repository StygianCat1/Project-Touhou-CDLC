using Script.Player.Capacity.Enum;
using UnityEngine;

public class PassivePowerGain : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.PassiveSingleUse;
    [SerializeField] public int powerCapacity = 40;
    [SerializeField] public bool wasUsed;

    private void Start()
    {
        stats = GetComponent<Stats>();
        if (!wasUsed)
        {
            GivePower();
        }
    }

    public void GivePower()
    {
        stats.power += powerCapacity;
        wasUsed = true;
    }
}
