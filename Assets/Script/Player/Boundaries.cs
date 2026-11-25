using UnityEngine;

public class Boundaries : MonoBehaviour
{
    //Vector 2 to get the lenght & width of the stage
    [SerializeField] public Vector2 boundariesSize;
    
    //Float to get width of player character
    [SerializeField] public float objectWidth = 2f;
    //Float to get lenght of the player character
    [SerializeField] public float objectLenght = 3.5f;

    // private variable that will be used to get the half of the player character width
    private float width;
    // private variable that will be used to get the half of the player character lenght
    private float lenght;
    // private variable that will be used to get the half of the boundary size
    private Vector2 boundariesHalfSize;
    

    private void Start()
    {
        //Set half sizes
        width = objectWidth / 2;
        lenght = objectLenght / 2;
        boundariesHalfSize = new Vector2(boundariesSize.x * 0.5f, boundariesSize.y * 0.5f);
    }

    
    //Script to check if character is in boundaries (check the position with width & lenght added to it)
    public bool CheckBoundaries(Vector3 newPos)
    {
        //Check if new Pos is in boundary 
        if (newPos.x < boundariesHalfSize.x - width && newPos.x > -boundariesHalfSize.x + width && newPos.z < boundariesHalfSize.y - lenght && newPos.z > -boundariesHalfSize.y + lenght)
        {
            return true;
        }
        return false;
        
        
    }
}
    