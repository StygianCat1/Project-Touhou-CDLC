using Script.Player.Capacity.Enum;
using UnityEngine;

public class ActiveMegaProjectile : MonoBehaviour
{
    private Shoot _shoot;
    
    [SerializeField] public CapacityType capacityType = CapacityType.Active;
    [SerializeField] public GameObject MegaProjectilePrefab;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shoot = GetComponent<Shoot>();
    }

    public void ShootMegaprojectile()
    {
        GameObject shot = Instantiate(MegaProjectilePrefab, _shoot.primaryAttackMuzzle.transform.position, _shoot.primaryAttackMuzzle.transform.rotation);
        shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
    }
}
