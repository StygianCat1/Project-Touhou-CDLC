using System.Collections.Generic;
using UnityEngine;

public class StageLenght : MonoBehaviour
{
    //List of GameObject, normally two that will help to get the lenght of the stage 
    [SerializeField] public List<GameObject> stageLenghts;
    
    //lenght of the stage after check
    [SerializeField] public float lenghtOfTheStage;

    private void Start()
    {
        //Check to get lenght of the stage, will be used by the boss for some attack
        lenghtOfTheStage = Vector3.Distance(stageLenghts[0].transform.position, stageLenghts[1].transform.position);
    }
}
