using System.Collections.Generic;
using UnityEngine;

public class BossMouvement : MonoBehaviour
{
    private BossStats bossStats;
    private List<GameObject> waypointsList;
    
    private bool canMove = true;

    public bool Move
    {
        get { return canMove; }
        set
        {
            canMove = value;
            if (value)
            {
                MoveToRandomWaypoint();
            }
        }
    }
    
    private bool firstMove = true;
    private bool randomDone;
    private GameObject randomWaypoint;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossStats = GetComponent<BossStats>();
        waypointsList = bossStats.pathToFollow.waypoints;

    }

    // Update is called once per frame
    void Update()
    {
        if (firstMove)
        {
            MovemenToFirstWaypoint(waypointsList[waypointsList.Count - 1]);
            return;
        }

        if (Move)
        {
            MoveToRandomWaypoint();
        }
    }

    private void MoveToRandomWaypoint()
    {
        if (!randomDone)
        {
            randomWaypoint = waypointsList[Random.Range(1, waypointsList.Count-1)];
            randomDone = true;
        }

        if (Vector3.Distance(transform.position, randomWaypoint.transform.position) < 0.1f)
        {
            print("got ot random waypoint");
            Move = false;
            print("say to other script that can attack");
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, randomWaypoint.transform.position, bossStats.speed * Time.deltaTime);
    }

    private void MovemenToFirstWaypoint(GameObject target)
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            print("got to target");
            firstMove = false;
        }

        transform.position = Vector3.MoveTowards(transform.position,target.transform.position,bossStats.speed * Time.deltaTime); 
    }
}
