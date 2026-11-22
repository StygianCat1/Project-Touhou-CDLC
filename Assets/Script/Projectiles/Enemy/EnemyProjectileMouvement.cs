using UnityEngine;

public class EnemyProjectileMouvement : MonoBehaviour
{
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField] public Vector3 direction = Vector3.forward;

    private void Start()
    {
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
