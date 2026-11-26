using System.Collections.Generic;
using Script.Enemy.Boss;
using Unity.Mathematics.Geometry;
using UnityEngine;


[System.Serializable]
public class BossAttackPattern
{
    //Type of attack of the boss
    public BossAttacktype BossAttackType; 
    //Number of shot in attack
    [Range(1,160)] public int numberOfShot;
    //Number of bullet per shot
    [Range(1,120)] public int numberOfBulletPerShot;
    //Time between shots
    [Range(0.05f, 1.5f)] public float timeBetweenShots;
    
    //Prefab of projectile type 1
    public GameObject projectile1Prefab;
    //Prefab of projectile type 2
    public GameObject projectile2Prefab;
}

public class BossAttack : MonoBehaviour
{
    //Boss movement ref
    private BossMouvement bossMouvement;
    //Boss stats ref
    private BossStats bossStats;
    //Player GameObject ref
    private GameObject playerRef;

    //List of the pattern the boss has, need to be on par with the boss number of live
    [SerializeField] public List<BossAttackPattern> bossAttackPattern;
    
    //Pos where the bullet will spawn
    [SerializeField] public GameObject bulletSpawn;
    //Adjust the rotation of where bullet may spawn
    [SerializeField] public GameObject spawnAdjust;
    //Ref of stage lenght to get the lenght
    [SerializeField] public StageLenght stageLenght;
    
    //Index of boss pattern
    [SerializeField] public int bossPatternIndex;
    //Bool to stop attack
    [SerializeField] public bool stopAttack;

    //Index of boss shot
    private int indexOfShot;
    //Bool to do switch rings attcak
    private bool ringsFlipFlop;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Reference to component
        bossMouvement = GetComponent<BossMouvement>();
        bossStats = GetComponent<BossStats>();
        //Ref to player character
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //Boss pattern index is equal to its number of life
        bossPatternIndex = bossStats.nbrOfLife;
    }

    public void Attack()
    {
        //Check if has attack
        if (bossAttackPattern.Count == 0)
        {
            print("no attack in the list");
            return;
        }

        //Reset variables
        indexOfShot = 0;
        stopAttack = false;
        //Many if to check what type of attack (is not optimal at all, but know no other way)
        if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.RingsAndCurtain) 
        { 
            RingsAndCurtainAttack();
        }
        else if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.Rings)
        { 
            RingsAttack();
        }
        else if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.WaveCurtain)
        {
            WaveCurtainAttack();
        }
        else if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.SpiralBackAndForth)
        {
            SpiralAttack();   
        }
        else if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.GridsAndAimedShot)
        {
            GridsAndAimedShotAttack();
        }
        else if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.FloralPattern)
        {
            FloralPatternAttack();
        }
        else if (bossAttackPattern[bossPatternIndex].BossAttackType == BossAttacktype.Raindrop)
        {
            RaindropAttack();
        }
    }


    private void RingsAndCurtainAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            // Ring attack part (use both projectile prefab to allow ring to move differently, put many bullet per shot for harder movement  but not too many to let character go through gaps)
            
            //Angle in degree of the attack
            float angleStep = 360 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                //Set rotation 
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                //Spawn projectile
                Instantiate(bossAttackPattern[bossPatternIndex].projectile2Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            
            //Curtain attack part (use projectile prefab 1) (make it that the projectile have either disorder on them or a bigger size, for difficulty purpose) (number of bullet is divided by two for this attack to allow better ring)
            
            //Distance between each projectile
            float distanceBetweenBullet = stageLenght.lenghtOfTheStage / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot * 2;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot / 2; i++)
            {
                //Set rotation
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, -180, 0f);
                //Spawn Bullet
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, new Vector3(stageLenght.stageLenghts[1].transform.position.x + i * distanceBetweenBullet, stageLenght.stageLenghts[1].transform.position.y, stageLenght.stageLenghts[1].transform.position.z + Mathf.Sin(i) * 2.5f), bulletSpawn.transform.rotation);
                
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            Invoke(nameof(RingsAndCurtainAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }

    private void RingsAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            // Ring attack part (use both projectile prefab to allow ring to move differently, put many bullet per shot for harder movement  but not too many to let character go through gaps)
            
            //Angle in degree of the attack
            float angleStep = 360 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                //Check for ring flipflop
                if (ringsFlipFlop)
                {
                    //Set Rotation
                    bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                    //Spawn projectile
                    Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
                }

                //Check for not ring flipflop
                if (!ringsFlipFlop)
                {
                    //Set Rotation
                    bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                    //Spawn projectile
                    Instantiate(bossAttackPattern[bossPatternIndex].projectile2Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
                }
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            //Set ring flipflop to it's inverse 
            ringsFlipFlop = !ringsFlipFlop;
            Invoke(nameof(RingsAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }

    private void WaveCurtainAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            //Curtain attack part (use projectile prefab 1) (make it that the projectile have either disorder on them or a bigger size, for difficulty purpose)
            float distanceBetweenBullet = stageLenght.lenghtOfTheStage / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                //Set rotation
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, -180, 0f);
                //SPawn projectile
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, new Vector3(stageLenght.stageLenghts[1].transform.position.x + i * distanceBetweenBullet, stageLenght.stageLenghts[1].transform.position.y, stageLenght.stageLenghts[1].transform.position.z + Mathf.Sin(i) * 2.5f), bulletSpawn.transform.rotation);
                
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            Invoke(nameof(WaveCurtainAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }
    
    private void SpiralAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            //Spiral attack part (use projectile prefab 1) (make it that the projectile have disorder on them for difficulty)
            
            //Angle in degree of the attack
            float angleStep = 120 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                //Set rotation
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,100 + i * angleStep + indexOfShot * 18 , 0f);
                //SPawn projectile
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            Invoke(nameof(SpiralAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }    
    
    private void GridsAndAimedShotAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            //Grid attack part (use projectile prefab 1) (make it that the projectile have disorder on them for difficulty)
            float distanceBetweenBullet = stageLenght.lenghtOfTheStage / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, -180, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, new Vector3(stageLenght.stageLenghts[1].transform.position.x + i * distanceBetweenBullet, stageLenght.stageLenghts[1].transform.position.y, stageLenght.stageLenghts[1].transform.position.z), bulletSpawn.transform.rotation);
            }
            
            //Aimed Shot part (use projectile prefab 2) (keep base shot with the possible grid modifier
            
            //Angle in degree of the attack
            float angleStep = 45 / Mathf.RoundToInt(bossAttackPattern[bossPatternIndex].numberOfBulletPerShot /2);
            for (int i = 0; i < Mathf.RoundToInt(bossAttackPattern[bossPatternIndex].numberOfBulletPerShot /2); i++)
            {
                //Make rotate look at playerRef
                spawnAdjust.transform.LookAt(playerRef.transform);
                //Set rotation
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, (spawnAdjust.transform.rotation.eulerAngles.y - 45 / 2) + i * angleStep, 0f);
                //Spawn projectile
                Instantiate(bossAttackPattern[bossPatternIndex].projectile2Prefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            Invoke(nameof(GridsAndAimedShotAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }    
    
    private void FloralPatternAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            // Floral attack part (use projectile prefab 1 for both (use whatever type of projectile as long as there is not too many projectile on screen (too many = undodgeable / unfair
            
            //Angle in degree of the attack
            float angleStep = 360 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            //two time a for to make one go left & the other right to make floral pattern
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                //Set rotation
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,i * angleStep + indexOfShot * 8, 0f);
                //Spawn projectile
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                //Set rotation
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,i * angleStep + indexOfShot * -8, 0f);
                //Spawn projectile
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            Invoke(nameof(FloralPatternAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }

    private void RaindropAttack()
    {
        print(indexOfShot);
        print(bossAttackPattern[bossPatternIndex].numberOfShot);
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            //If has to, then stop attack
            if (stopAttack)
            {
                //Call movement 
                Invoke(nameof(CallMovement), 2);
                return;
            }
            
            //RainDrop attack part (use projectile prefab 1) (make it so that the projectile are the falling type)
            
            //Angle in degree of the attack
            float angleStep = 90 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                {
                    //Make rotation look at player character ref
                    spawnAdjust.transform.LookAt(playerRef.transform);
                    //Set rotation
                    bulletSpawn.transform.rotation = Quaternion.Euler(0f, (spawnAdjust.transform.rotation.eulerAngles.y - 90 / 2) + i * angleStep, 0f);
                    //Spawn projectile 
                    Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                }
            }
            //Increase the index & call again the function
            indexOfShot += 1;
            Invoke(nameof(RaindropAttack), bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }

    //call movement ==> tell boss to move
    private void CallMovement()
    {
        bossMouvement.ReshufflePos();
        bossMouvement.Move = true;
    }
}
