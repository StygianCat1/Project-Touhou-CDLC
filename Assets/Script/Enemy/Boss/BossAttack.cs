using System.Collections.Generic;
using Script.Enemy.Boss;
using Unity.Mathematics.Geometry;
using UnityEngine;

[System.Serializable]
public class BossAttackPattern
{
    public BossAttacktype BossAttackType; 
    [Range(1,160)] public int numberOfShot;
    [Range(1,120)] public int numberOfBulletPerShot;
    [Range(0.05f, 1.5f)] public float timeBetweenShots;
    
    public GameObject projectile1Prefab;
    public GameObject projectile2Prefab;
}


public class BossAttack : MonoBehaviour
{
    private BossMouvement bossMouvement;
    private BossStats bossStats;
    private GameObject playerRef;

    [SerializeField] public List<BossAttackPattern> bossAttackPattern;
    
    [SerializeField] public GameObject bulletSpawn;
    [SerializeField] public GameObject spawnAdjust;
    [SerializeField] public StageLenght stageLenght;
    
    [SerializeField] public int bossPatternIndex;
    [SerializeField] public bool stopAttack;

    private int indexOfShot;
    private bool ringsFlipFlop = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bossMouvement = GetComponent<BossMouvement>();
        bossStats = GetComponent<BossStats>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        bossPatternIndex = bossStats.nbrOfLife;
    }

    public void Attack()
    {
        if (bossAttackPattern.Count == 0)
        {
            print("no attack in the list");
            return;
        }

        indexOfShot = 0;
        stopAttack = false;
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
                return;
            }
            
            // Ring attack part (use both projectible prefab to allow ring to move differently, put many bullet per shot for harder movement  but not too many to let character go through gaps)
            float angleStep = 360 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile2Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            //Curtain attack part (use projectile prefab 1) (make it that the projectile have either disorder on them or a bigger size, for difficulty purpose) (number of bullet is divided by two for this attack to allow better ring)
            float distanceBetweenBullet = stageLenght.lenghtOfTheStage / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot * 2;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot / 2; i++)
            {
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, -180, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, new Vector3(stageLenght.stageLenghts[1].transform.position.x + i * distanceBetweenBullet, stageLenght.stageLenghts[1].transform.position.y, stageLenght.stageLenghts[1].transform.position.z + Mathf.Sin(i) * 2.5f), bulletSpawn.transform.rotation);
                
            }
            
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
                return;
            }
            // Ring attack part (use both projectible prefab to allow ring to move differently, put many bullet per shot for harder movement  but not too many to let character go through gaps)
            float angleStep = 360 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                if (ringsFlipFlop)
                {
                    bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                    Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
                }

                if (!ringsFlipFlop)
                {
                    bulletSpawn.transform.rotation =  Quaternion.Euler(0f, i * angleStep, 0f);
                    Instantiate(bossAttackPattern[bossPatternIndex].projectile2Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
                }
            }
            
            indexOfShot += 1;
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
                return;
            }
            
            //Curtain attack part (use projectile prefab 1) (make it that the projectile have either disorder on them or a bigger size, for difficulty purpose)
            float distanceBetweenBullet = stageLenght.lenghtOfTheStage / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, -180, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, new Vector3(stageLenght.stageLenghts[1].transform.position.x + i * distanceBetweenBullet, stageLenght.stageLenghts[1].transform.position.y, stageLenght.stageLenghts[1].transform.position.z + Mathf.Sin(i) * 2.5f), bulletSpawn.transform.rotation);
                
            }
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
                return;
            }
            
            //Spiral attack part (use projectile prefab 1) (make it that the projectile have disorder on them for difficulty)
            float angleStep = 120 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,100 + i * angleStep + indexOfShot * 18 , 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
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
            float angleStep = 45 / Mathf.RoundToInt(bossAttackPattern[bossPatternIndex].numberOfBulletPerShot /2);
            for (int i = 0; i < Mathf.RoundToInt(bossAttackPattern[bossPatternIndex].numberOfBulletPerShot /2); i++)
            {
                spawnAdjust.transform.LookAt(playerRef.transform);
                bulletSpawn.transform.rotation = Quaternion.Euler(0f, (spawnAdjust.transform.rotation.eulerAngles.y - 45 / 2) + i * angleStep, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile2Prefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            }
            
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
                return;
            }
            
            // Floral attack part (use projectile prefab 1 for both (use whatever type of projectile as long as there is not too many projectile on screen (too many = undodgeable / unfair
            float angleStep = 360 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,i * angleStep + indexOfShot * 8, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                bulletSpawn.transform.rotation =  Quaternion.Euler(0f,i * angleStep + indexOfShot * -8, 0f);
                Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            }
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
            if (stopAttack)
            {
                Invoke(nameof(CallMovement), 8);
                return;
            }
            
            //RainDrop attack part (use projectile prefab 1) (make it so that the projectile are the falling type)
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {
                float angleStep = 90 / bossAttackPattern[bossPatternIndex].numberOfBulletPerShot;
                {
                    spawnAdjust.transform.LookAt(playerRef.transform);
                    bulletSpawn.transform.rotation = Quaternion.Euler(0f, (spawnAdjust.transform.rotation.eulerAngles.y - 90 / 2) + i * angleStep, 0f);
                    Instantiate(bossAttackPattern[bossPatternIndex].projectile1Prefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                }
            }
            indexOfShot += 1;
            Invoke(nameof(RaindropAttack), bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 2);
    }

    private void CallMovement()
    {
        bossMouvement.ReshufflePos();
        bossMouvement.Move = true;
    }
}
