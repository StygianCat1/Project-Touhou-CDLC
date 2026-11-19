using Script.Collectible;
using UnityEngine;

public class CollectibleType : MonoBehaviour
{
    [SerializeField] public TypeOfCollectible collectibleType;
    [SerializeField] public int collectibleNbr;
    
    public void Collectible(Stats characterStats) 
    {
        if (collectibleType == TypeOfCollectible.Power)
        {
            characterStats.power += collectibleNbr;
        }
        else if (collectibleType == TypeOfCollectible.Points)
        {
            characterStats.points += collectibleNbr;
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
