using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private EnemyDeath _deathScript;
    
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;

    [SerializeField]
    public float currentHealth
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
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
        health = maxHealth;
    }
}
