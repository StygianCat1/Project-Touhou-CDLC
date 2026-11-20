using UnityEngine;
using UnityEngine.Animations;

public class PrimaryAttack : MonoBehaviour
{
    private Stats stats;
    private Shoot _shoot;
    
    [SerializeField] public GameObject primaryAttack1;
    [SerializeField] public float delayPrimaryAttack1 = 1;
    private float timerAttack1;
    [SerializeField] public GameObject primaryAttack2;
    [SerializeField] public float delayPrimaryAttack2 = 1;
    private float timerAttack2;


    private void Start()
    {
        stats = GetComponent<Stats>();
        _shoot = GetComponent<Shoot>();
        timerAttack1 = delayPrimaryAttack1;
        timerAttack2 = delayPrimaryAttack2;
    }

    public void ShootPrimaryAttack1(GameObject SpawnGameObject)
    {
        if (TimerPrimaryAttack1())
        {
            GameObject shot;
            shot = Instantiate(primaryAttack1, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            shot = Instantiate(primaryAttack1, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
        }
    }

    public void ShootPrimaryAttack2(GameObject SpawnGameObject)
    {
        if (TimerPrimaryAttack2())
        {
            GameObject shot;
            if (stats.power < 45)
            {
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 45 && stats.power < 90)
            {
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position + new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position, SpawnGameObject.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(primaryAttack2, SpawnGameObject.transform.position - new Vector3(0.75f,0,0), SpawnGameObject.transform.rotation);;
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 90)
            {
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

    private bool TimerPrimaryAttack1()
    {
        if (timerAttack1 >= delayPrimaryAttack1)
        {
            timerAttack1 = 0;
            return true;
        }
        timerAttack1 += Time.unscaledDeltaTime * _shoot.attackSpeedBoostMultiplier;
        return false;
    }

    private bool TimerPrimaryAttack2()
    {
        if (timerAttack2 >= delayPrimaryAttack2)
        {
            timerAttack2 = 0;
            return true;
        }
        timerAttack2 += Time.unscaledDeltaTime * _shoot.attackSpeedBoostMultiplier;
        return false;
    }
}
