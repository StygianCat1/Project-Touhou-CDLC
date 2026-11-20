using UnityEngine;

public class SecondaryAttack : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public GameObject secondaryAttack1;
    [SerializeField] public float delaySecondaryAttack1 = 1.5f;
    private float timerAttack1;
    [SerializeField] public GameObject secondaryAttack2;
    [SerializeField] public float delaySecondaryAttack2 = 1.5f;
    private float timerAttack2;
    
    private void Start()
    {
        stats = GetComponent<Stats>();
        timerAttack1 = delaySecondaryAttack1;
        timerAttack2 = delaySecondaryAttack2;
    }


    public void ShootSecondaryAttack1(GameObject SpawnGameObject1, GameObject SpawnGameObject2, GameObject SpawnGameObject3, GameObject SpawnGameObject4, GameObject SpawnGameObject5)
    {
        if (TimerSecondaryAttack1())
        {
            GameObject shot;
            if (stats.power < 45)
            {
                shot = Instantiate(secondaryAttack1, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 45 && stats.power < 90)
            {
                shot = Instantiate(secondaryAttack1, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
                shot = Instantiate(secondaryAttack1, SpawnGameObject5.transform.position, SpawnGameObject5.transform.rotation);
                shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            }
            else if (stats.power >= 90)
            {
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
        if (TimerSecondaryAttack2())
        {
            GameObject shot;
            shot = Instantiate(secondaryAttack2, SpawnGameObject1.transform.position, SpawnGameObject1.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
            shot =Instantiate(secondaryAttack2, SpawnGameObject2.transform.position, SpawnGameObject2.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
        }
    }
    
    
    private bool TimerSecondaryAttack1()
    {
        if (timerAttack1 >= delaySecondaryAttack1)
        {
            timerAttack1 = 0;
            return true;
        }
        timerAttack1 += Time.unscaledDeltaTime;
        return false;
    }

    private bool TimerSecondaryAttack2()
    {
        if (timerAttack2 >= delaySecondaryAttack2)
        {
            timerAttack2 = 0;
            return true;
        }
        timerAttack2 += Time.unscaledDeltaTime;
        return false;
    }
    
    
    
}
