using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private BossMouvement bossMouvement;
    private BossStats bossStats;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossMouvement = GetComponent<BossMouvement>();
        bossStats = GetComponent<BossStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
