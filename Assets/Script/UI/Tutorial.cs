using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] public List<GameObject> tutorials;
    
    
    
    [SerializeField] public Stats stats;
    
    [SerializeField] public GameObject waveSpawner;


    private int indexInTutorial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }
    
    public void continueInTutorial()
    {
        tutorials[indexInTutorial + 1].SetActive(true);
        tutorials[indexInTutorial].SetActive(false);
        indexInTutorial += 1;
    }
    
    public void returInTutorial()
    {
        tutorials[indexInTutorial - 1].SetActive(true);
        tutorials[indexInTutorial].SetActive(false);
        indexInTutorial -= 1;
    }
    
    
    public void LaunchWave()
    {
        gameObject.SetActive(false);
        waveSpawner.SetActive(true);
    }
}
