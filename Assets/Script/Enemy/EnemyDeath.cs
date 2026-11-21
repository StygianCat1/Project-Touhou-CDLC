using System;
using UnityEngine;
using Random=UnityEngine.Random;


[System.Serializable]
public class droppableCollectible
{
    [SerializeField] public GameObject collectiblePrefab;
    [SerializeField][Range(0,100)] public int dropPercentage;
}

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]public droppableCollectible[] dropCollectibles;

    public void DropOnDeath()
    {
        for (int i = 0; i < dropCollectibles.Length; i++)
        {
            if (Random.Range(0, 100) <= dropCollectibles[i].dropPercentage)
            {
              Instantiate(dropCollectibles[i].collectiblePrefab, transform.position, Quaternion.identity);
              break;
            }
        }
        Destroy(gameObject);
    }
}
