using UnityEngine;

public class Boundaries : MonoBehaviour
{
    
    [SerializeField] public Vector2 boundariesSize;
    [SerializeField] public float objectWidth = 2f;
    [SerializeField] public float objectLenght = 3.5f;

    private float width;
    private float lenght;
    private Vector2 boundariesHalfSize;
    

    private void Start()
    {
        width = objectWidth / 2;
        lenght = objectLenght / 2;
        boundariesHalfSize = new Vector2(boundariesSize.x * 0.5f, boundariesSize.y * 0.5f);
    }

    public bool CheckBoundaries(Vector3 newPos)
    {
        if (newPos.x < boundariesHalfSize.x - width && newPos.x > -boundariesHalfSize.x + width && newPos.z < boundariesHalfSize.y - lenght && newPos.z > -boundariesHalfSize.y + lenght)
        {
            return true;
        }
        return false;
        
        
    }
}
    