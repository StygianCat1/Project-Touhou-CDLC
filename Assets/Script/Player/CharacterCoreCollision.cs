using UnityEngine;

public class CharacterCoreCollision : MonoBehaviour
{
    private Stats stats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name + " collision with core");
    }
}
