using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    
    private  PlayerInput _playerInput;
    private PlayerMouvement _playerMouvement;
    
    [SerializeField] public Vector2 moveInput;
    [SerializeField] public bool shotInput;
    [SerializeField] public bool bombInput;
    [SerializeField] public bool slowMovementInput;
    [SerializeField] public bool abilityInput;
    [SerializeField] public bool skipInput;
    [SerializeField] public bool pauseInput;

    public bool bombCheck
    {
        get
        {
            return bombInput;
        }
        set
        {
            bombInput = value;
            BombUsageChange();
        }
    }


    [SerializeField]
    public bool slowMovementCheck
    {
        get
        {
            return slowMovementInput;
        }
        set
        {
            slowMovementInput = value;
            SlowMouvementUsageChange();
        }
    }

    public bool abilityCheck
    {
        get
        {
            return abilityInput;
        }
        set
        {
            abilityInput = value;
            AbilityUsageChange();
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMouvement = GetComponent<PlayerMouvement>();
    }
    
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnShot(InputValue value)
    {
        shotInput = value.isPressed;
    }
    
    public void OnBomb(InputValue value)
    {
        bombCheck = value.isPressed;
    }

    public void BombUsageChange()
    {

    }

    public void OnSlowMovement(InputValue value)
    {
        slowMovementCheck = value.isPressed;
    }
    
    public void SlowMouvementUsageChange()
    {
        _playerMouvement.ChangeForSlowMovement(slowMovementCheck);
    }

    public void OnUseActiveCapacity(InputValue value)
    {
        abilityCheck = value.isPressed;
    }

    public void AbilityUsageChange()
    {
        
    }
    
    public void OnSkip(InputValue value)
    {
        skipInput = value.isPressed;
    }
    
    public void OnPaused(InputValue value)
    {
        pauseInput = value.isPressed;
    }
}

