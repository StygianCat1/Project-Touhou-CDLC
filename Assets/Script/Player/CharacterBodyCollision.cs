using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBodyCollision : MonoBehaviour
{
    private Stats stats;

    [SerializeField] private List<GameObject> closeProjectiles;
    
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

        if (other.gameObject.tag == "EnemyProjectile")
        {
            closeProjectiles.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < closeProjectiles.Count; i++)
        {
            if (closeProjectiles[i] == other.gameObject)
            {
                stats.grazeNbr += 1;
                closeProjectiles.Remove(closeProjectiles[i]);
            }
        }
    }
}
