using UnityEngine;

public class ProblemSolver : MonoBehaviour
{
    //Just tell what stage we're on
    [SerializeField] public int stage = 1;  
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set Time.Timescale to 1 in case
        Time.timeScale = 1f;
    }
}
