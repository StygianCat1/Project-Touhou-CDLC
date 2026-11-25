using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleMouvement : MonoBehaviour
{
    //Ref to character as a GameObject
    private GameObject characterRef;
    //direction that will get a get set to change its value
    private float direction = 1;
    //float that will be used in collectible movement on Z axis
    private float angle;
    //bool that can change the collectible movement mode
    private bool moveToPlayer;
    
    //float for the speed of the collectible
    [SerializeField] public float mouvementSpeed = 15f;
    //float for the speed the direction change
    [SerializeField] public float directionChangeSpeed = 1f;
    //The Z axis movement of the collectible variable  
    [SerializeField] public float angleChangeSpeed = 4f;
    //the speed of the collectable when it goes toward the player
    [SerializeField] public float speedTowardPlayer = 100f;
    
    //private float to add a random effect in the height the collectible goes to when jumping
    private float randomHeightSpeed;

    private void Start()
    {
        //Reference the component
        characterRef = GameObject.FindGameObjectWithTag("Player");
        //Set angle as random for whole duration
        angle = Random.Range(-1f,1f);
        //Set jump height as normal height + a random number that is between -+ 1/3 of the normal jump height
        randomHeightSpeed = directionChangeSpeed + Random.Range(-directionChangeSpeed * 0.3f, directionChangeSpeed * 0.3f);
        Destroy(gameObject, 10f);
    }

    
    //The get set of direction, that has just a clamp to clamp the direction change value
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
        //check if move to player is true, can only be activated by bomb or player going to the top of the screen
        if (moveToPlayer)
        {
            //Function to make collectible go to player
            MoveTowardPlayer();
            return;
        }
        
        //If it does not go toward player, allow movement on vertical axis
        VerticalMoveCollectible();
        //If the direction is not "down" then allow movement on horizontal axis 
        if (direction >= -0.8f)
        {
            HorizontalMoveCollectible(angle);
        }
    }

    //Function for movement on vertical axis
    private void VerticalMoveCollectible()
    {
        //Move the collectible on the vertical axis
        transform.Translate(new Vector3(0f ,0f , directionref * mouvementSpeed * Time.deltaTime), Space.World);
        //dhange with time, allowing to feel like the collectable does a jump then fall 
        directionref -= Time.deltaTime * randomHeightSpeed;
    }

    //Function for movement on horizontal axis
    private void HorizontalMoveCollectible(float moveAngle)
    {
        //Move the collectible on the horizontal axis
        transform.Translate(new Vector3(moveAngle * angleChangeSpeed * Time.deltaTime, 0f, 0f), Space.World);
    }

    
    //Function for collectables movement toward player
    public void MoveTowardPlayer()
    {
        //Move toward player with pos
        transform.position = Vector3.MoveTowards(transform.position, characterRef.transform.position, speedTowardPlayer * Time.deltaTime);
        //If false then set it to true, for the void Update to be able to call it repetitivly 
        if (!moveToPlayer)
        {
            moveToPlayer = true;
        }
    }
}
