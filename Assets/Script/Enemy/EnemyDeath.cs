using System;
using UnityEngine;
using Random=UnityEngine.Random;


[System.Serializable]
public class droppableCollectible
{
    //List of GameObject, normally collectibles that the enemy may drop
    [SerializeField] public GameObject collectiblePrefab;
    //Range of drop
    [SerializeField][Range(0,100)] public int dropPercentage;
}

public class EnemyDeath : MonoBehaviour
{
    // Array of the possible collectable that enemy drop, with a drop rate
    [SerializeField]public droppableCollectible[] dropCollectibles;

    //To not call drop collectible many time
    private bool wasCalled;

    public void DropOnDeath()
    {
        if (!wasCalled)
        {
            wasCalled = true;
            //For size of the list
            for (int i = 0; i < dropCollectibles.Length; i++)
            {
                //if the random give out a true result
                if (Random.Range(0, 100) <= dropCollectibles[i].dropPercentage)
                {
                    //Spawn the collectable and stop everytjing
                    Instantiate(dropCollectibles[i].collectiblePrefab, transform.position, Quaternion.identity);
                    break;
                }
            }

            //Destroy Enemy
            Destroy(gameObject);
        }
    }
}
