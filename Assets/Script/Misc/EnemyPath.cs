using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] public List<GameObject> waypoints;
    [SerializeField] public bool needDebug;
    
    
    private void Update()
    {
        //if (needDebug)
        //{
        //    DebugLineTrace();
        //}
    }

    private void DebugLineTrace()
    {
        for (int i = 0; i < waypoints.Count-2; i++)
        {
            Debug.DrawLine(waypoints[i].transform.position, waypoints[i+1].transform.position, Color.red);
        }
    }
}
