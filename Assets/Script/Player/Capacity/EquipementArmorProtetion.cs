using Script.Player.Capacity.Enum;
using UnityEngine;

public class EquipementArmorProtetion : MonoBehaviour
{
    private Stats _stats;
    
    [SerializeField] public CapacityType capacityType = CapacityType.Equipment;
    [SerializeField] public int maxRandomNumber = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    public bool CheckIfTakeDamage()
    {
        int currentNumber = Random.Range(0, maxRandomNumber);
        if (currentNumber == 8)
        {
            return true;
        }
        return false;
    }
}
