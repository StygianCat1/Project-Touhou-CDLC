using System.Collections.Generic;
using UnityEngine;

public class EnemyMouvement : MonoBehaviour
{
    private EnemyStats stats;
    private EnemyShoot shoot;
    private List<GameObject> waypointsList;
    private int waypointIndex;
    private bool mouvementStopped;
    
    [SerializeField][Range(0,20)] public float waitTime;

    public int waypointPos
    {
        get {return waypointIndex;}
        set
        {
            waypointIndex = value;
            if (value == 2)
            {
                
                shoot.Shoot(); StopMouvement();
            }
            if (value == waypointsList.Count){Destroy(gameObject);}
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        shoot = GetComponent<EnemyShoot>();
        waypointsList = stats.pathToFollow.waypoints;
    }

    private void Update()
    {
        MoveTowardNextWaypoint();
    }

    private void MoveTowardNextWaypoint()
    {
        if (!mouvementStopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointsList[waypointIndex].transform.position, stats.speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypointsList[waypointPos].transform.position) < 0.1f)
            {
                waypointPos += 1;
            }
        }
    }

    private void StopMouvement()
    {
        if (waitTime > 0)
        {
            mouvementStopped = true;
            Invoke(nameof(ContinueMouvement), waitTime);
        }
    }

    private void ContinueMouvement()
    {
        mouvementStopped = false;
    }
}
