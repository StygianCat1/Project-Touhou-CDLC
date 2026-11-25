using System.Collections.Generic;
using UnityEngine;

public class BossMouvement : MonoBehaviour
{
    //Ref to boss stats
    private BossStats bossStats;
    //ref to boss attack
    private BossAttack bossAttacks;
    //List of GameObject that will be used as Waypoints
    private List<GameObject> waypointsList;
    
    //check when can move
    private bool canMove = true;

    
    //Getter Setter to activate movement when can move is true
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
    
    //Bool to check if first move was made
    private bool firstMove = true;
    //Check if random location was done
    private bool randomDone;
    //GameObject Ref that will be used as the next waypoint
    private GameObject randomWaypoint;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Reference the component
        bossStats = GetComponent<BossStats>();
        bossAttacks = GetComponent<BossAttack>();
        //Get ref to the list of waypoints
        waypointsList = bossStats.pathToFollow.waypoints;

    }

    // Update is called once per frame
    void Update()
    {
        //Check if first move was made
        if (firstMove)
        {
            //Move to the first waypoint
            MovemenToFirstWaypoint(waypointsList[waypointsList.Count - 1]);
            return;
        }

        //Check if can move
        if (Move)
        {
            //Move to a random waypoint (can be the same he is on)
            MoveToRandomWaypoint();
        }
    }

    private void MoveToRandomWaypoint()
    {
        //if random done is false
        if (!randomDone)
        {
            //Set a new random and block this part
            randomWaypoint = waypointsList[Random.Range(1, waypointsList.Count-1)];
            randomDone = true;
        }
        
        //Check boss distance to waypoint
        if (Vector3.Distance(transform.position, randomWaypoint.transform.position) < 0.1f)
        {
            //If arrived then can attack
            Move = false;
            bossAttacks.Attack();
            return;
        }
        //If boss has not arrived then move him
        transform.position = Vector3.MoveTowards(transform.position, randomWaypoint.transform.position, bossStats.speed * Time.deltaTime);
    }

    //Reset the random for next waypoint
    public void ReshufflePos()
    {
        randomDone = false;
    }

    //Move to first waypoint
    private void MovemenToFirstWaypoint(GameObject target)
    {
        //Check ditance between boss and first waipoint
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            //If arrived to target, block the function
            firstMove = false;
        }
        //If boss has not arrived then move him 
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position,bossStats.speed * Time.deltaTime); 
    }
}
