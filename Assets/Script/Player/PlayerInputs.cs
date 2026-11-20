using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerMouvement _playerMouvement;
    private ApparanceChange _apparanceChange;
    private Shoot _shoot;
    private Bomb _bomb;
    private PlayerPause _playerPause;
    
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
            _bomb.BombExplosion();
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
            _playerMouvement.ChangeForSlowMovement(slowMovementCheck);
            _apparanceChange.ChangeApparanceOnSlow(slowMovementCheck);
            _shoot.MoveSecondaryAttackSocketForFocus(slowMovementCheck);
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
        }
    }

    public bool pauseCheck
    {
        get {return pauseInput;}
        set
        {
            pauseInput = value;
            print("aled");
            _playerPause.Pause();
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _playerMouvement = GetComponent<PlayerMouvement>();
        _apparanceChange = GetComponent<ApparanceChange>();
        _shoot = GetComponent<Shoot>();
        _bomb = GetComponent<Bomb>();
        _playerPause = GetComponent<PlayerPause>();

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

    public void OnSlowMovement(InputValue value)
    {
        slowMovementCheck = value.isPressed;
    }

    public void OnUseActiveCapacity(InputValue value)
    {
        abilityCheck = value.isPressed;
    }
    
    
    public void OnSkip(InputValue value)
    {
        skipInput = value.isPressed;
    }
    
    public void OnPaused(InputValue value)
    {
        pauseCheck = value.isPressed;
    }
}

