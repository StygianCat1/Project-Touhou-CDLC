using UnityEngine;

public class EnemyProjectileMouvement : MonoBehaviour
{
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField] public Vector3 direction = Vector3.forward;
    [SerializeField] public bool disorder;

    private void Start()
    {
        if (disorder)
        {
            attackSpeed += Random.Range(-0.5f, 0.5f); 
        }
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
    }
}
