using UnityEngine;

public class CharacterCoreCollision : MonoBehaviour
{
    private Stats stats;
    
    [SerializeField] public bool invulnerable;
    
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
        
        if (other.tag == "EnemyProjectile")
        {            
            Destroy(other.gameObject);
            if (invulnerable)
            {
                return;
            }
            stats.health -= 1;
        }

        if (other.tag == "Enemy")
        {
            if (invulnerable)
            {
                return;
            }

            stats.health -= 1;
        }
    }
}