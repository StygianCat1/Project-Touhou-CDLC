using UnityEngine;

public class PlayerProjectileMouvement : MonoBehaviour
{
    //Set the speed of the projectile
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
        //A basic forward translation boosted by the speed of the projectile
        transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
    }
}
