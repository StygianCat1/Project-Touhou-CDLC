using System;
using UnityEngine;

public class ActivateCollectibleMovement : MonoBehaviour
{
    //Array to get all collectable on stage 
    private GameObject[] collectibles;
    
    //Function to make collectables goes toward player
    public void ActractCollectible()
    {
        //Get all the ref
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        //For every collectable in array
        for (int i = 0; i < collectibles.Length; i++)
        {
            //Set then the collectables to move toward player mode
            collectibles[i].GetComponent<CollectibleMouvement>().MoveTowardPlayer();
        }
        //Clear the array of any collectable
        Array.Clear(collectibles, 0, collectibles.Length);
    }
}
