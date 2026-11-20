using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;

    [SerializeField]
    public float currentHealth
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            if (health == 0)
            {
                //do event to make enemy die
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        health = maxHealth;
    }

    private void Death()
    {
        CreateCollectible();
        //Play sound on destroy
        //Add particle effect
        Destroy(gameObject,0.1f);
    }

    private void CreateCollectible()
    {
        
    }
}
