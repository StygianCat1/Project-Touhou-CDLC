using UnityEngine;

public class CharacterCoreCollision : MonoBehaviour
{
    private Stats stats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponentInParent<Stats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ActivateCollectibleMovement>() != null)
        {
            other.gameObject.GetComponent<ActivateCollectibleMovement>().ActractCollectible();
        }
        
        if (other.tag == "Enemy" || other.tag == "EnemyProjectile")
        {
            //stats.health -= 1;
            print("deal damage to health in stats + add invincibility for short period of time");
        }
    }
}