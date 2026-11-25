using Script.Collectible;
using UnityEngine;

public class CollectibleType : MonoBehaviour
{
    //Set the type of collectible, the GameObject is
    [SerializeField] public TypeOfCollectible collectibleType;
    //Give the value a collectible will give if taken by player
    [SerializeField] public int collectibleNbr;
    //The number of point earned by player if taken
    [SerializeField] public int pointEarned;
    
    public void Collectible(Stats characterStats) 
    {
        //Vast number of IF that check the type of the collectible and if they found the right one, then they give their value to the character Stats script
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
        
        //And add the point earned to Stats script score
        characterStats.score += pointEarned;
    }
}
