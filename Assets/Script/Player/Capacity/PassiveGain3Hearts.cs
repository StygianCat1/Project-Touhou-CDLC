using Script.Player.Capacity.Enum;
using UnityEngine;

public class PassiveGain3Hearts : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.PassiveSingleUse;
    [SerializeField] public int healCapacity = 3;
    [SerializeField] public bool wasUsed;

    private void Start()
    {
        stats = GetComponent<Stats>();
        if (!wasUsed)
        {
            GiveHealth();
        }
    }

    public void GiveHealth()
    {
        stats.health += healCapacity;
        wasUsed = true;
    }
}
