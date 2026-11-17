using UnityEngine;

public class PlayerTrackingProjectileMouvement : MonoBehaviour
{
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField] public GameObject target;

    private void Start()
    {
        SearchForTarget();
        Destroy(gameObject, 2f);
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
        // code to search for the closest target
         // target = "put result" 
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
