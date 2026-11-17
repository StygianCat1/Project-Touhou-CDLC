using UnityEngine;
using UnityEngine.Animations;

public class PrimaryAttack : MonoBehaviour
{
    [SerializeField] public GameObject primaryAttack1;
    [SerializeField] public float delayPrimaryAttack1 = 1;
    private float timerAttack1;
    [SerializeField] public GameObject primaryAttack2;
    [SerializeField] public float delayPrimaryAttack2 = 1;
    private float timerAttack2;


    private void Start()
    {
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
            shot = Instantiate(primaryAttack1, SpawnGameObject.transform.position + new Vector3(-0.75f,0,0), SpawnGameObject.transform.rotation);
            shot.GetComponent<PlayerProjectileDamage>().stats = GetComponent<Stats>();
        }
    }

    public void ShootPrimaryAttack2(GameObject SpawnGameObject)
    {
        if (TimerPrimaryAttack2())
        {
            //Instantiate(primaryAttack2, SpawnGameObject.transform.position, SpawnGameObject.transform.rotation);
            //Instantiate(primaryAttack1, SpawnGameObject.transform.position, SpawnGameObject.transform.rotation);
        }
    }

    private bool TimerPrimaryAttack1()
    {
        if (timerAttack1 >= delayPrimaryAttack1)
        {
            timerAttack1 = 0;
            return true;
        }
        timerAttack1 += Time.deltaTime;
        return false;
    }

    private bool TimerPrimaryAttack2()
    {
        if (timerAttack2 >= delayPrimaryAttack2)
        {
            timerAttack2 = 0;
            return true;
        }
        timerAttack2 += Time.deltaTime;
        return false;
    }
}
