using System.Collections.Generic;
using UnityEngine;

public class StageLenght : MonoBehaviour
{
    [SerializeField] public List<GameObject> stageLenghts;
    
    [SerializeField] public float lenghtOfTheStage;

    private void Start()
    {
        lenghtOfTheStage = Vector3.Distance(stageLenghts[0].transform.position, stageLenghts[1].transform.position);
    }
}
