using System;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    private PlayerProjectileDamage _playerProjectileDamage;

    [SerializeField] public bool isGiantProjectile;
    
    private void Start()
    {
        _playerProjectileDamage = GetComponent<PlayerProjectileDamage>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyStats>().currentHealth -= _playerProjectileDamage.totalDamage;
            if (!isGiantProjectile)
            {
                Destroy(gameObject);
            }
        }
    }
}
