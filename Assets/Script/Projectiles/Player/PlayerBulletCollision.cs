using System;
using UnityEngine;
using Math = Unity.Mathematics.Geometry.Math;

public class PlayerBulletCollision : MonoBehaviour
{
    //Ref to damage done by projectles
    private PlayerProjectileDamage _playerProjectileDamage;
    //Ref to stats
    private Stats _stats;

    //Check for if is giant projectile
    [SerializeField] public bool isGiantProjectile;
    
    private void Start()
    {
        //Reference the component
        _playerProjectileDamage = GetComponent<PlayerProjectileDamage>();
        _stats = GetComponent<PlayerProjectileDamage>().stats;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Check if enemy
        if (other.tag == "Enemy")
        {
            //Check if has enemy stats component
            if (other.GetComponent<EnemyStats>() != null)
            {
                //If it has one then deal damage to it
                other.GetComponent<EnemyStats>().currentHealth -= _playerProjectileDamage.totalDamage;
                //Give score when hurting enemy
                _stats.score += Mathf.RoundToInt(_playerProjectileDamage.totalDamage);
                //And if it isn't a giant projectile then destroy it
                if (!isGiantProjectile)
                {
                    Destroy(gameObject);
                }
            }
            //Check if has boss stats component
            else if (other.GetComponent<BossStats>() != null)
            {
                //If it has one then deal damage to it
                other.GetComponent<BossStats>().currentHealth -= _playerProjectileDamage.totalDamage;
                //Give score when hurting boss
                _stats.score += Mathf.RoundToInt(_playerProjectileDamage.totalDamage);
                //And if it isn't a giant projectile then destroy it
                if (!isGiantProjectile)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
