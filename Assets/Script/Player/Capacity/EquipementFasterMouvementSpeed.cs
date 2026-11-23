using Script.Player.Capacity.Enum;
using UnityEngine;

public class EquipementFasterMouvementSpeed : MonoBehaviour
{
    private PlayerMouvement _playerMouvement;
    
    [SerializeField] public CapacityType capacityType = CapacityType.Equipment;
    [SerializeField] public float boostMouvementSpeed = 1.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerMouvement = GetComponent<PlayerMouvement>();
        MoveFaster();
    }

    public void MoveFaster()
    {
        _playerMouvement.speedBoostMultiplier = boostMouvementSpeed;
    }
}
