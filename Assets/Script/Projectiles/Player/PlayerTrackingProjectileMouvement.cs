using UnityEngine;

public class PlayerTrackingProjectileMouvement : MonoBehaviour
{
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField] private GameObject[] targetList;
    [SerializeField] public GameObject target;

    private void Start()
    {
        SearchForTarget();
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (target != null)
        {
            MoveTracingBullet();
        }
        else
        {
            MoveBullet();
        }
    }

    private void SearchForTarget()
    {
        GameObject closestTarget = null;
        targetList = GameObject.FindGameObjectsWithTag("Enemy");
        for (var targets = 0; targets < targetList.Length; targets++)
        {
            if (closestTarget == null)
            {
                closestTarget = targetList[targets];
            }
            if (Vector3.Distance(transform.position, closestTarget.transform.position) > Vector3.Distance(transform.position, targetList[targets].transform.position))
            {
                closestTarget = targetList[targets];
            }
        }
        target = closestTarget;
    }

    private void MoveTracingBullet()
    {
        transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime, Space.Self);
        gameObject.transform.LookAt(target.transform);  
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
    }
}
