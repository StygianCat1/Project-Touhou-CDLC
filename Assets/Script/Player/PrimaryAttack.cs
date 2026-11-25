using UnityEngine;
using UnityEngine.Animations;

public class PrimaryAttack : MonoBehaviour
{
    //Ref to character stats
    private Stats stats;
    //Ref to shoot script
    private Shoot _shoot;
    
    //Projectile prefab 1
    [SerializeField] public GameObject primaryAttack1;
    //Delay between each attack 1
    [SerializeField] public float delayPrimaryAttack1 = 1;
    //Timer of the delay 1
    private float timerAttack1;
    //Projectile prefab 2
    [SerializeField] public GameObject primaryAttack2;
    //Delay between each attack 2
    [SerializeField] public float delayPrimaryAttack2 = 1;
    //Timer of the delay 2
    private float timerAttack2;


    private void Start()
    {
        //Reference the component
        stats = GetComponent<Stats>();
        _shoot = GetComponent<Shoot>();
        //Set timers to delay value
        timerAttack1 = delayPrimaryAttack1;
        timerAttack2 = delayPrimaryAttack2;
    }

    //Shoot primary attack 1
    public void ShootPrimaryAttack1(GameObject SpawnGameObject)
    {
        //Check if the time to attack
        if (TimerPrimaryAttack1())
        {
            //Set shot
            GameObject shot;
            //Instantiate prefab (in different position) & change value with shot 
            shot = Instantiate(primaryAttack1, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            shot = Instantiate(primaryAttack1, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
        }
    }

    //Shoot primary prefab 2
    public void ShootPrimaryAttack2(GameObject SpawnGameObject)
    {
        //Check if the time to attack
        if (TimerPrimaryAttack2())
        {
            //Set shot
            GameObject shot;
            //Check attack depending on power
            if (stats.power < 45)
            {
                //Instantiate prefab (in different position) & change value with shot 
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 45 && stats.power < 90)
            {
                //Instantiate prefab (in different position) & change value with shot 
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position, SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);;
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 90)
            {
                //Instantiate prefab (in different position) & change value with shot 
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position + new Vector3(1.5f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position, SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);;
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position - new Vector3(1.5f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
        }
    }

    //Timer between each attack
    private bool TimerPrimaryAttack1()
    {
        //Check timer 
        if (timerAttack1 >= delayPrimaryAttack1)
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
    private bool TimerPrimaryAttack2()
    {
        //Check timer 
        if (timerAttack2 >= delayPrimaryAttack2)
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
