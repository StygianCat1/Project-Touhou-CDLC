using UnityEngine;

public class CharacterCoreCollision : MonoBehaviour
{
    //Ref to character stats
    private Stats stats;
    
    //Bool for invulnerability
    [SerializeField] public bool invulnerable;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Reference the component
        stats = GetComponentInParent<Stats>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Check when goes to the top to make the collectables goes toward the character, if it exist
        if (other.gameObject.GetComponent<ActivateCollectibleMovement>() != null)
        {
            //Make all the collectables goes toward the character
            other.gameObject.GetComponent<ActivateCollectibleMovement>().ActractCollectible();
        }
        
        //If it's an enemy projectile
        if (other.tag == "EnemyProjectile")
        {            
            //Destroy it, check if invulnerable and if not then take damage
            Destroy(other.gameObject);
            if (invulnerable)
            {
                return;
            }
            stats.health -= 1;
        }

        //Check if invulnerable and if not then take damage
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