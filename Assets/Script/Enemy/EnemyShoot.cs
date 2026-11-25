using Script.Enemy;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //gte ref to player
    private GameObject playerRef;
    
    //Type of attack the eney can use
    [SerializeField] public EnemyAttackType typeOfAttack;
    //Reference to the bullet the enemy use
    [SerializeField] public GameObject bullet;
    //Position where the bullet will spawn 
    [SerializeField] public GameObject bulletSpawn;
    //GameObject that will be used to adjust the rotation of the shot
    [SerializeField] public GameObject spawnAdjust;
    //Number of shot the enemy can have
    [SerializeField][Range(1,80)] public int numberOfShot;
    //Number of bullets per shot
    [SerializeField][Range(1,20)] public int numberOfBulletPerShot;
    //Time between each shot
    [SerializeField][Range(0.05f, 0.5f)] public float timeBetweenShots;
    
    //The change in rotation
    private Vector3 rotationChange;
    //The index of the shot
    private int indexOfShot;

    private void Start()
    {
        //Reference the Gameobject
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    
    
    public void Shoot()
    {
        //Many if that check the type of the attack to set a shoot mode
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
    
    
    //Shoot forward moving projectile in 360 degree
    private void BaseRadialShot()
    {
        //As long as the index of shot is inferior to the number of shot
        if (indexOfShot < numberOfShot)
        {
            //The angle between each bulley
            float angleStep = 360 / numberOfBulletPerShot;
            //for every bullet in the shot
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                //Change the rotation depending on angleStep
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                //Spawn a bullet
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Add to index and recall the function after waiting the time between shots
            indexOfShot += 1;
            Invoke(nameof(BaseRadialShot), timeBetweenShots);
        }
    }

    private void BaseSpiralShot()
    {
        //As long as the index of shot is inferior to the number of shot
        if (indexOfShot < numberOfShot)
        {
            //The angle between each bulley
            float angleStep = 360 / numberOfBulletPerShot;
            
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                //Change the rotation depending on angleStep and the index of shot
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,i * angleStep + indexOfShot * 8, 0f);
                //Spawn a bullet
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Add to index and recall the function after waiting the time between shots
            indexOfShot += 1;
            Invoke(nameof(BaseSpiralShot), timeBetweenShots);
        }
    }

    private void AimedFanShot()
    {
        //As long as the index of shot is inferior to the number of shot
        if (indexOfShot < numberOfShot)
        {
            //The angle between each bulley
            float angleStep = 90 / numberOfBulletPerShot;
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                //Make transform look at playerRef to aim at him
                spawnAdjust.transform.LookAt(playerRef.transform);
                //Change the rotation depending on angleStep
                bulletSpawn.transform.rotation = Quaternion.Euler(0f,(spawnAdjust.transform.rotation.eulerAngles.y - 90/2) + i * angleStep, 0f);
                //Spawn a bullet
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Add to index and recall the function after waiting the time between shots
            indexOfShot += 1;
            Invoke(nameof(AimedFanShot), timeBetweenShots);
        }
    }
    
    private void SpiraFanShot()
    {
        //As long as the index of shot is inferior to the number of shot
        if (indexOfShot < numberOfShot)
        {
            //The angle between each bulley
            float angleStep = 120 / numberOfBulletPerShot;
            
            for (int i = 0; i < numberOfBulletPerShot; i++)
            {
                //Change the rotation depending on angleStep and the index of shot
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,100 + i * angleStep + indexOfShot * 8, 0f);
                //Spawn a bullet
                Instantiate(bullet, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Add to index and recall the function after waiting the time between shots
            indexOfShot += 1;
            Invoke(nameof(SpiraFanShot), timeBetweenShots);
        }
    }
}
