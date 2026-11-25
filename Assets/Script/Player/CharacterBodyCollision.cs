using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBodyCollision : MonoBehaviour
{
    //Ref to character Stats
    private Stats stats;

    //List of GameObject, will be used for Graze stats
    [SerializeField] private List<GameObject> closeProjectiles;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Reference the component
        stats = GetComponentInParent<Stats>();
    }

    //Check if enter collider (need to have rigidbody & collision set trigger) 
    private void OnTriggerEnter(Collider other)
    {
        //If it is a collectable
        if (other.gameObject.GetComponent<CollectibleType>() != null)
        {
            //Set value given in stats and destroy it
            other.gameObject.GetComponent<CollectibleType>().Collectible(stats);
            Destroy(other.gameObject);
        }

        //If is an enemy or one of their projectile 
        if (other.tag == "Enemy" || other.tag == "EnemyProjectile")
        {
            //Add to the list of GameObject for graze
            closeProjectiles.Add(other.gameObject);
        }
    }
    
    //Check if exit collider (need to have rigidbody & collision set trigger) 
    private void OnTriggerExit(Collider other)
    {
        //Check in the list of GameObject
        for (int i = 0; i < closeProjectiles.Count; i++)
        {
            //Check if the projectile is in the list
            if (closeProjectiles[i] == other.gameObject)
            {
                //If it is the add to graze and remove him from the list
                stats.graze += 1;
                closeProjectiles.Remove(closeProjectiles[i]);
            }
        }
    }
}
