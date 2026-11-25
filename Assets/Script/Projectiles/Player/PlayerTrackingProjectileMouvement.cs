using UnityEngine;

public class PlayerTrackingProjectileMouvement : MonoBehaviour
{
    //Set the speed of the projectile
    [SerializeField] public float attackSpeed = 1f;
    //Array of all possible target
    [SerializeField] private GameObject[] targetList;
    //The target the projectile will chase
    [SerializeField] public GameObject target;

    private void Start()
    {
        //Search for a target
        SearchForTarget();
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        //If there is a target then move toward it
        if (target != null)
        {
            MoveTracingBullet();
        }
        //If target is null then switch back to normal forward movement
        else
        {
            MoveBullet();
        }
    }

    private void SearchForTarget()
    {
        //Will be used to check all the target
        GameObject closestTarget = null;
        //Fill the target array with all enemies on stage
        targetList = GameObject.FindGameObjectsWithTag("Enemy");
        //Loop for all enemy in target List
        for (var targets = 0; targets < targetList.Length; targets++)
        {
            //if no closest target then set it
            if (closestTarget == null)
            {
                closestTarget = targetList[targets];
            }
            // if closest target is farther than the next target, change closest target
            if (Vector3.Distance(transform.position, closestTarget.transform.position) > Vector3.Distance(transform.position, targetList[targets].transform.position))
            {
                closestTarget = targetList[targets];
            }
        }
        //set target as closest target at the end
        target = closestTarget;
    }

    private void MoveTracingBullet()
    {
        //Move forward as a basic forward translation
        transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime, Space.Self);
        //Make it look at for rotation change and tracking enemy target
        gameObject.transform.LookAt(target.transform);  
    }

    private void MoveBullet()
    {
        //A basic forward translation boosted by the speed of the projectile
        transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
    }
}
