using Unity.Mathematics.Geometry;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //Ref to death script 
    private EnemyDeath _deathScript;
    
    //Float for enemy health
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    
    //enemy path to follow ref
    [SerializeField] public EnemyPath pathToFollow;
    //Speed of the enemy
    [SerializeField] public float speed = 10f;
    
    
    //Getter Setter of enemy health to make enemy drop collectable on "death"
    public float currentHealth
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            if (health <= 0)
            {
                _deathScript.DropOnDeath();
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Reference the component
        _deathScript = GetComponent<EnemyDeath>();
        
    }

    
    //Health change for wave spawner 
    public void ChangeHealthValue(float value)
    {
        health  = value;
        maxHealth = health;
    }
}
