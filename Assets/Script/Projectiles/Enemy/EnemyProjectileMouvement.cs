using DefaultNamespace;
using UnityEngine;

public class EnemyProjectileMouvement : MonoBehaviour
{
    //Projectile type for change in trajectory
    [SerializeField] public EnemyProjectileType projectileType;
    //Speed of the projectile
    [SerializeField] public float attackSpeed = 1f;
    //Degree on curve rotation if is curving projectile type
    [SerializeField][Range(0.05f,0.3f)] public float degreeOfRotationOnCurve = 0.1f;
    //Movement direction
    [SerializeField] public Vector3 direction = Vector3.forward;
    //Bool to add disorder in bullet speed
    [SerializeField] public bool disorder;
    
    //Fall mutliplier for falling type projectile
    private float fallMutliplier = 0f;

    private void Start()
    {
        //If it has disorder
        if (disorder)
        {
            //Change the speed of the attack
            attackSpeed += Random.Range(-0.25f * attackSpeed, 0.25f * attackSpeed); 
        }
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        //Many if to check what type of projectile it is and what movement they need to use
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
        //If it moves straight then just a basic translation
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
    }
    
    private void MoveBulletCurvingRight()
    {
        //If it is curving then just a basic translation & a Rotate on the right
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0,1,0), degreeOfRotationOnCurve);
    }
    
    private void MoveBulletCurvingLeft()
    {
        //If it is curving then just a basic translation & a Rotate on the left
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0,-1,0), degreeOfRotationOnCurve);
    }
    
    private void MoveBulletFalling()
    {
        //if it is falling then a basic translation & another that pull it to the ground more and more
        transform.Translate(direction * attackSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.back * fallMutliplier * Time.deltaTime, Space.World);
        //fallMultiplier increase each time, pulling stronger & stronger each call
        fallMutliplier += 0.1f;
    }
}
