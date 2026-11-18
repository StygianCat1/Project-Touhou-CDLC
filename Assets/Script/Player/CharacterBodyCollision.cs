using System;
using UnityEngine;

public class CharacterBodyCollision : MonoBehaviour
{
    private Stats stats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponentInParent<Stats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollectibleType>() != null)
        {
            other.gameObject.GetComponent<CollectibleType>().Collectible(stats);
            Destroy(other.gameObject, 0.1f);
        }
    }
}
