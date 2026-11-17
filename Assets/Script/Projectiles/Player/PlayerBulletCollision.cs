using System;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    private PlayerProjectileDamage _playerProjectileDamage;
    
    private void Start()
    {
        _playerProjectileDamage = GetComponent<PlayerProjectileDamage>();
    }

    public void OnCollisionEnter(UnityEngine.Collision other)
    {
        //do something like deal damage and play sound + destroy
    }
}
