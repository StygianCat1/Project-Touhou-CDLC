using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private EnemyDeath _deathScript;
    
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    
    
    [SerializeField] public EnemyPath pathToFollow;
    [SerializeField] public float speed = 10f;

    [SerializeField]
    public float currentHealth
    {
        get { return health; }
        set
        {
            if (health <= 0)
            {
                print("enemy died");
                _deathScript.DropOnDeath();
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _deathScript = GetComponent<EnemyDeath>();
    }

    public void ChangeHealthValue(float value)
    {
        health  = value;
        maxHealth = health;
    }
}
