using UnityEditor.UIElements;
using UnityEngine;

public class ProjectileMouvement : MonoBehaviour
{
    
   [SerializeField] public float projectileSpeed = 10f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyProjectile()
    {
        // Play sound on damage dealt
        Destroy(gameObject);
    }
}
