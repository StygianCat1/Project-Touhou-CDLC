using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    //List of waypoint as GameObject
    [SerializeField] public List<GameObject> waypoints;
    //bool for the debug option
    [SerializeField] public bool needDebug;
    
    
    //Line for debuging the path
    private void Update()
    {
        //if (needDebug)
        //{
        //    DebugLineTrace();
        //}
    }

    //A Drawl line type of debug to see the enemy path
    private void DebugLineTrace()
    {
        //for any waypoint in list
        for (int i = 0; i < waypoints.Count-2; i++)
        {
            //Draw line between the waypoint and the next one
            Debug.DrawLine(waypoints[i].transform.position, waypoints[i+1].transform.position, Color.red);
        }
    }
}
