using Script.Player.Capacity.Enum;
using UnityEngine;

public class PassiveGain3Hearts : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.PassiveSingleUse;
    [SerializeField] public int healCapacity = 3;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void GiveHealth()
    {
        stats.health += healCapacity;
    }
}
