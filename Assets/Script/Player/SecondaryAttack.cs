using UnityEngine;

public class SecondaryAttack : MonoBehaviour
{
    //Ref to character stats
    private Stats stats;
    //Ref to shoot script
    private Shoot _shoot;
    
    //Projectile prefab 1
    [SerializeField] public GameObject secondaryAttack1;
    //Delay between each attack 1
    [SerializeField] public float delaySecondaryAttack1 = 1.5f;
    //Timer of the delay 1
    private float timerAttack1;
    //Projectile prefab 2
    [SerializeField] public GameObject secondaryAttack2;
    //Delay between each attack 2
    [SerializeField] public float delaySecondaryAttack2 = 1.5f;
    //Timer of the delay 2
    private float timerAttack2;
    
    private void Start()
    {
        //Reference the component
        stats = GetComponent<Stats>();
        _shoot = GetComponent<Shoot>();
        //Set timers to delay value
        timerAttack1 = delaySecondaryAttack1;
        timerAttack2 = delaySecondaryAttack2;
    }


    public void ShootSecondaryAttack1(GameObject SpawnGameObject1, GameObject SpawnGameObject2, GameObject SpawnGameObject3, GameObject SpawnGameObject4, GameObject SpawnGameObject5)
    {
        //Check if the time to attack
        if (TimerSecondaryAttack1())
        {
            //Set shot
            GameObject shot;
            //Check attack depending on power
            if (stats.power < 45)
            {
                //Instantiate prefab (in different position) & change value with shot 
                shot = Instantiate(secondaryAttack1, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 45 && stats.power < 90)
            {
                //Instantiate prefab (in different position) & change value with shot 
                shot = Instantiate(secondaryAttack1, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject5.transform.position, SpawnGameObject5.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 90)
            {
                //Instantiate prefab (in different position) & change value with shot 
                shot = Instantiate(secondaryAttack1, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject3.transform.position, SpawnGameObject3.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject4.transform.position, SpawnGameObject4.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
        }
    }

    public void ShootSecondaryAttack2(GameObject SpawnGameObject1, GameObject SpawnGameObject2, GameObject SpawnGameObject3, GameObject SpawnGameObject4, GameObject SpawnGameObject5)
    {
        //Check if the time to attack
        if (TimerSecondaryAttack2())
        {
            //Set shot
            GameObject shot;
            //Instantiate prefab (in different position) & change value with shot 
            shot = Instantiate(secondaryAttack2, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            shot =Instantiate(secondaryAttack2, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
        }
    }
    
    
    //Timer between each attack
    private bool TimerSecondaryAttack1()
    {
        //Check timer 
        if (timerAttack1 >= delaySecondaryAttack1)
        {
            //Set timer to 0 and return true
            timerAttack1 = 0;
            return true;
        }
        //Increment timer value and return false
        timerAttack1 += Time.unscaledDeltaTime * _shoot.attackSpeedBoostMultiplier;
        return false;
    }

    //Timer between each attack
    private bool TimerSecondaryAttack2()
    {
        //Check timer 
        if (timerAttack2 >= delaySecondaryAttack2)
        {
            //Set timer to 0 and return true
            timerAttack2 = 0;
            return true;
        }
        //Increment timer value and return false
        timerAttack2 += Time.unscaledDeltaTime * _shoot.attackSpeedBoostMultiplier;
        return false;
    }
}
