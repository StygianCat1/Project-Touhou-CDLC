using UnityEngine;

public class PlayerProjectileMouvement : MonoBehaviour
{
    [SerializeField] public float attackSpeed = 1f;

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
        transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
    }
}
