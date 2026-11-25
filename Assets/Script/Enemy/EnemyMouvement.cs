using System.Collections.Generic;
using UnityEngine;

public class EnemyMouvement : MonoBehaviour
{
    //Enemy stats ref, to get path / waypoint ref
    private EnemyStats stats;
    //enemy shoot ref, to shoot at chosen time
    private EnemyShoot shoot;
    
    //List of the waypoint the enemy has
    private List<GameObject> waypointsList;
    //Index of the waypoint he is on 
    private int waypointIndex;
    //bool to tell if has to stop
    private bool mouvementStopped;
    
    //Wait time of the enemy
    [SerializeField][Range(0,20)] public float waitTime;

    
    //Getter Setter of waypoint, when enemy is on the second waypoint then he may shoot and wait + destroy object when arrived at last waypoint
    public int waypointPos
    {
        get {return waypointIndex;}
        set
        {
            waypointIndex = value;
            if (value == 2)
            {
                shoot.Shoot(); 
                StopMouvement();
            }
            if (value == waypointsList.Count){Destroy(gameObject);}
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Reference the component
        stats = GetComponent<EnemyStats>();
        shoot = GetComponent<EnemyShoot>();
        //Get the list of waypoint from enemy stats
        waypointsList = stats.pathToFollow.waypoints;
    }

    private void Update()
    {
        //Always call movemet toward the next waypoint
        MoveTowardNextWaypoint();
    }

    private void MoveTowardNextWaypoint()
    {
        //If the movement is not stopped
        if (!mouvementStopped)
        {
            //Move toward the next position that is a waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypointsList[waypointIndex].transform.position, stats.speed * Time.deltaTime);
            //If at next position
            if (Vector3.Distance(transform.position, waypointsList[waypointPos].transform.position) < 0.1f)
            {
                //Add to waypoint index to get a new Pos
                waypointPos += 1;
            }
        }
    }

    //Stop the movement  if needed
    private void StopMouvement()
    {
        //If  wait time is superior to zero then make enemy wait + launch timer for wait time
        if (waitTime > 0)
        {
            mouvementStopped = true;
            Invoke(nameof(ContinueMouvement), waitTime);
        }
    }

    //Set back movement after some time
    private void ContinueMouvement()
    {
        mouvementStopped = false;
    }
}
