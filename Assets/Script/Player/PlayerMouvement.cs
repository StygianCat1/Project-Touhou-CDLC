using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    //Ref to the script that manage the input
    private PlayerInputs _playerInputs;
    //Ref to boundary script
    private Boundaries _boundaries;
    
    //Variable to change character speed
    [SerializeField] public float movementSpeedMultiplier = 10f;
    //Variable that will be used by another script to slow movement
    [SerializeField] public float slowSpeed = 1f;
    //Multiplier be it for boost in speed
    [SerializeField] public float speedBoostMultiplier = 1f;
    
    //Check if timer is paused but only by a capacity
    [SerializeField] public bool timePaused = false;
    
    
    void Start()
    {
        //Reference the component 
        _playerInputs = GetComponent<PlayerInputs>();
        _boundaries = GetComponent<Boundaries>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    void Mouvement()
    {
        //Create a new pos for test purpose
        Vector3 NewPos = new Vector3(0, 0, 0);
        if (timePaused)
        {
            //If time is paused by capacity, allow character to have a newPos (on a 2D axis) with Time.unscaleDeltaTime
            NewPos = new Vector3(_playerInputs.moveInput.x * movementSpeedMultiplier * slowSpeed , transform.position.y, _playerInputs.moveInput.y * movementSpeedMultiplier * slowSpeed * speedBoostMultiplier) *  Time.unscaledDeltaTime;
        }
        else
        {
            //Give character a newPos (on a 2D axis)
            NewPos = new Vector3(_playerInputs.moveInput.x * movementSpeedMultiplier * slowSpeed , transform.position.y, _playerInputs.moveInput.y * movementSpeedMultiplier * slowSpeed * speedBoostMultiplier) * Time.deltaTime;
            
        }
        
        // Check with Boundaries script if the newPos is in boundary
        if (_boundaries.CheckBoundaries(transform.position + NewPos))
        {
            //if he is, then allow character to move to the newPos position
            transform.Translate(NewPos);
        }
    }

    public void ChangeForSlowMovement(bool slow)
    {
        //If given bool named snow is true
        if (slow)
        {
            //slow the slowSpeed variable
            slowSpeed = 0.6f;
            return;
        }
        //else set it back to 1
        slowSpeed = 1f;
    }
}
