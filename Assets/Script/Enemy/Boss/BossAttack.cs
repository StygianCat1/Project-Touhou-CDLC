using System.Collections.Generic;
using Script.Enemy.Boss;
using UnityEngine;

[System.Serializable]
public class BossAttackPattern
{
    public BossAttacktype BossAttackType; 
    [Range(1,80)] public int numberOfShot;
    [Range(1,20)] public int numberOfBulletPerShot;
    [Range(0.05f, 0.5f)] public float timeBetweenShots;
    
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
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bossMouvement = GetComponent<BossMouvement>();
        bossStats = GetComponent<BossStats>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        bossPatternIndex = bossStats.nbrOfLife - 1;
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
            SpiralBackAndForthAttack();   
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
                Invoke(nameof(CallMovement), 2);
                return;
            }
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {

            }
            indexOfShot += 1;
            Invoke(nameof(RingsAndCurtainAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 5);
    }

    private void RingsAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {

            }
            indexOfShot += 1;
            Invoke(nameof(RingsAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 5);
    }

    private void WaveCurtainAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {

            }
            indexOfShot += 1;
            Invoke(nameof(WaveCurtainAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 5);
    }
    
    private void SpiralBackAndForthAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {

            }
            indexOfShot += 1;
            Invoke(nameof(SpiralBackAndForthAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 5);
    }    
    
    private void GridsAndAimedShotAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {

            }
            indexOfShot += 1;
            Invoke(nameof(GridsAndAimedShotAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 5);
    }    
    
    private void FloralPatternAttack()
    {
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
            for (int i = 0; i < bossAttackPattern[bossPatternIndex].numberOfBulletPerShot; i++)
            {

            }
            indexOfShot += 1;
            Invoke(nameof(FloralPatternAttack),bossAttackPattern[bossPatternIndex].timeBetweenShots);
            return;
        }
        Invoke(nameof(CallMovement), 5);
    }

    private void RaindropAttack()
    {
        print(indexOfShot);
        print(bossAttackPattern[bossPatternIndex].numberOfShot);
        if (indexOfShot < bossAttackPattern[bossPatternIndex].numberOfShot)
        {
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
        Invoke(nameof(CallMovement), 5);
    }

    private void CallMovement()
    {
        bossMouvement.ReshufflePos();
        bossMouvement.Move = true;
    }
}
