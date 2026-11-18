using Script.Collectible;
using UnityEngine;

public class CollectibleType : MonoBehaviour
{
    public Stats characterStats;
    
    [SerializeField] public TypeOfCollectible collectibleType;
    [SerializeField] public int collectibleNbr;
    
    public void Collectible() 
    {
        if (collectibleType == TypeOfCollectible.Power)
        {
            characterStats.power += collectibleNbr;
        }
        else if (collectibleType == TypeOfCollectible.Points)
        {
            characterStats.pointsNbr += collectibleNbr;
        }
        else if (collectibleType == TypeOfCollectible.Health)
        {
            characterStats.health += collectibleNbr;
        }
        else if (collectibleType == TypeOfCollectible.Bomb)
        {
            characterStats.bomb += collectibleNbr;
        }
    }
}
