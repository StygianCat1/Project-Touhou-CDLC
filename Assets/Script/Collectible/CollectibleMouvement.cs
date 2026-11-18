using System;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class CollectibleMouvement : MonoBehaviour
{
    private float direction = 1;
    private float angle = 0;
    
    [SerializeField] public float mouvementSpeed = 0.15f;
    [SerializeField] public float directionChangeSpeed = 0.8f;
    [SerializeField] public float angleChangeSpeed = 0.02f;

    private void Start()
    {
        angle = UnityEngine.Random.Range(-1f,1f);
        Destroy(gameObject, 4f);
    }

    private float directionref
    {
        get { return direction;}
        set
        {
            direction = Mathf.Clamp(value, -1f, 1f);
        }
    }
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        VerticlaMoveCollectible();
        if (direction >= -0.8f)
        {
            HorizontalMoveCollectible(angle);
        }
    }

    private void VerticlaMoveCollectible()
    {
        transform.Translate(new Vector3(0f ,0f , directionref * mouvementSpeed), Space.World);
        directionref -= Time.deltaTime * directionChangeSpeed;
    }

    private void HorizontalMoveCollectible(float moveAngle)
    {
        transform.Translate(new Vector3(moveAngle * angleChangeSpeed, 0f, 0f), Space.World);
    }
}
