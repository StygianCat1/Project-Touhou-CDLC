using Script.Enemy;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private GameObject playerRef;
    
    
    [SerializeField] public EnemyAttackType typeOfAttack;
    [SerializeField] public GameObject bullet;
    [SerializeField] public GameObject bulletSpawn;
    [SerializeField] public GameObject spawnAdjust;
    [SerializeField][Range(1,80)] public int numberOfShot;
    [SerializeField][Range(1,20)] public int numberOfBulletPerShot;
    [SerializeField][Range(0.05f, 0.5f)] public float timeBetweenShots;
    
    private Vector3 rotationChange;
    private int indexOfShot;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    
    
    public void Shoot()
    {
        print("shoot");
        if (typeOfAttack == EnemyAttackType.BaseRadialShot)
        {
            BaseRadialShot();
        }   
        else if (typeOfAttack == EnemyAttackType.BaseSpiralShot)
        {
            BaseSpiralShot();
        }
        else if (typeOfAttack == EnemyAttackType.AimedFanShot)
        {
            AimedFanShot();
        }
        else if (typeOfAttack == EnemyAttackType.SpiralFanShot)
        {
            SpiraFanShot();
        }
    }

    private void BaseRadialShot()
    {
        if (indexOfShot < numberOfShot)
        {
            float angleStep = 360 / numberOfBulletPerShot;
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            indexOfShot += 1;
            Invoke(nameof(BaseRadialShot), timeBetweenShots);
        }
    }

    private void BaseSpiralShot()
    {
        if (indexOfShot < numberOfShot)
        {
            float angleStep = 360 / numberOfBulletPerShot;
            
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,i * angleStep + indexOfShot * 8, 0f);
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            indexOfShot += 1;
            Invoke(nameof(BaseSpiralShot), timeBetweenShots);
        }
    }

    private void AimedFanShot()
    {
        if (indexOfShot < numberOfShot)
        {
            float angleStep = 90 / numberOfBulletPerShot;
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                spawnAdjust.transform.LookAt(playerRef.transform);
                bulletSpawn.transform.rotation = Quaternion.Euler(0f,(spawnAdjust.transform.rotation.eulerAngles.y - 90/2) + i * angleStep, 0f);
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            indexOfShot += 1;
            Invoke(nameof(AimedFanShot), timeBetweenShots);
        }
    }
    
    private void SpiraFanShot()
    {
        if (indexOfShot < numberOfShot)
        {
            
            float angleStep = 120 / numberOfBulletPerShot;
            
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,100 + i * angleStep + indexOfShot * 8, 0f);
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            
            indexOfShot += 1;
            Invoke(nameof(SpiraFanShot), timeBetweenShots);
        }
    }
}
