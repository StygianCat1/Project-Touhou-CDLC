using Script.Player.Capacity.Enum;
using UnityEngine;

public class ActiveFasterShootingSpeed : MonoBehaviour
{
    private Shoot _shoot;
    
    [SerializeField] public CapacityType capacityType = CapacityType.Active;
    [SerializeField] public float temporaryAttackSpeed = 2f;
    [SerializeField] public float boostDuration = 10f;
    [SerializeField] public bool isBoosted = false;
    
    private float boostTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shoot.GetComponent<Shoot>();
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
        _shoot.attackSpeedBoostMultiplier = 2f;
        isBoosted = true;
    }

    public void StopBoost()
    {
        _shoot.attackSpeedBoostMultiplier = 2f;
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
