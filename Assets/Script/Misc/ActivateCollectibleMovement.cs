using System;
using UnityEngine;

public class ActivateCollectibleMovement : MonoBehaviour
{
    private GameObject[] collectibles;
    
    
    public void ActractCollectible()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        for (int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i].GetComponent<CollectibleMouvement>().MoveTowardPlayer();
        }
        Array.Clear(collectibles, 0, collectibles.Length);
    }
}
