using DefaultNamespace;
using UnityEngine;

public class EnemyProjectileMouvement : MonoBehaviour
{
    [SerializeField] public EnemyProjectileType projectileType;
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField][Range(0.05f,0.3f)] public float degreeOfRotationOnCurve = 0.1f;
    [SerializeField] public Vector3 direction = Vector3.forward;
    [SerializeField] public bool disorder;

    private float fallMutliplier = 0f;

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
        if (projectileType == EnemyProjectileType.Straight)
        {
            MoveBulletStraight();
        }
        else if (projectileType == EnemyProjectileType.CurvingRight)
        {
            MoveBulletCurvingRight();
        }
        else if (projectileType == EnemyProjectileType.CurvingLeft)
        {
            MoveBulletCurvingLeft();
        }
        else if (projectileType == EnemyProjectileType.Falling)
        {
            MoveBulletFalling();
        }
        
    }

    private void MoveBulletStraight()
    {
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
    }
    
    private void MoveBulletCurvingRight()
    {
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0,1,0), degreeOfRotationOnCurve);
    }
    
    private void MoveBulletCurvingLeft()
    {
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0,-1,0), degreeOfRotationOnCurve);
    }
    
    private void MoveBulletFalling()
    {
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.back * fallMutliplier * Time.deltaTime, Space.World);
        fallMutliplier += 0.1f;
    }
}
