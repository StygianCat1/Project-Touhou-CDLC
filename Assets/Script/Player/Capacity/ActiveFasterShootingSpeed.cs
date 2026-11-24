using Script.Player.Capacity.Enum;
using UnityEngine;

public class ActiveFasterShootingSpeed : MonoBehaviour
{
    private Shoot _shoot;
    
    [SerializeField] public CapacityType capacityType = CapacityType.Active;
    [SerializeField] public float temporaryAttackSpeed = 2f;
    [SerializeField] public float boostDuration = 10f;
    [SerializeField] public bool isBoosted = false;
    [SerializeField] public int numberOfUse = 2;

    
    private float boostTimer = 0f;
    private float  normalAttackSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shoot = GetComponent<Shoot>();
        normalAttackSpeed = _shoot.attackSpeedBoostMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoosted)
        {
            Boosttimer();
        }
    }
    
    public void BoostShootSpeed()
    {
        if (isBoosted)
        {
            return;
        }
        
        if (numberOfUse != 0)
        {
            _shoot.attackSpeedBoostMultiplier = 2f;
            isBoosted = true;
            numberOfUse -= 1;
        }
    }

    public void StopBoost()
    {
        _shoot.attackSpeedBoostMultiplier = normalAttackSpeed;
    }

    private void Boosttimer()
    {
        if (boostTimer >= boostDuration)
        {
            boostTimer = 0;
            StopBoost();
        }
        boostTimer += Time.deltaTime;

    }
}
