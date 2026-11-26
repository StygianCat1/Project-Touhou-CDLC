using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    //ref to player mouvement
    private PlayerMouvement _playerMouvement;
    //ref to the apparance of the character
    private ApparanceChange _apparanceChange;
    //ref to the shoot script
    private Shoot _shoot;
    //ref to the bomb script
    private Bomb _bomb;
    //ref to the pause script
    private PlayerPause _playerPause;
    //Ref to the active ability that allow to shoot faster
    private ActiveFasterShootingSpeed _activeFasterShooting;
    //Ref to the active ability that allows to shoot a giant projectile
    private ActiveMegaProjectile _activeMegaProjectile;
    
    //Ref to all the input checked
    [SerializeField] public Vector2 moveInput;
    [SerializeField] public bool shotInput;
    [SerializeField] public bool bombInput;
    [SerializeField] public bool slowMovementInput;
    [SerializeField] public bool abilityInput;
    [SerializeField] public bool skipInput;
    [SerializeField] public bool pauseInput;

    
    //Getter Setter of bomb input
    public bool bombCheck
    {
        get
        {
            return bombInput;
        }
        set
        {
            //If value change then allow explosion
            bombInput = value;
            _bomb.BombExplosion();
        }
    }


    //getter Setter of slow movement / focus input
    public bool slowMovementCheck
    {
        get
        {
            return slowMovementInput;
        }
        set
        {
            //If value chang then change appearance, speed & attack socket pos 
            slowMovementInput = value;
            _playerMouvement.ChangeForSlowMovement(slowMovementCheck);
            _apparanceChange.ChangeApparanceOnSlow(slowMovementCheck);
            _shoot.MoveSecondaryAttackSocketForFocus(slowMovementCheck);
        }
    }

    //Getter Setter of ability input
    public bool abilityCheck
    {
        get
        {
            return abilityInput;
        }
        set
        {
            //If there's an ability active and enabled then use them
            abilityInput = value;
            if (_activeFasterShooting.isActiveAndEnabled){_activeFasterShooting.BoostShootSpeed();}
            if (_activeMegaProjectile.isActiveAndEnabled){_activeMegaProjectile.ShootMegaprojectile();}
        }
    }

    
    //Getter Setter of pause input
    public bool pauseCheck
    {
        get {return pauseInput;}
        set
        {
            //If pause then open pause menu
            pauseInput = value;
            _playerPause.Pause();
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Reference the component
        _playerMouvement = GetComponent<PlayerMouvement>();
        _apparanceChange = GetComponent<ApparanceChange>();
        _shoot = GetComponent<Shoot>();
        _bomb = GetComponent<Bomb>();
        _playerPause = GetComponent<PlayerPause>();
        _activeFasterShooting = GetComponent<ActiveFasterShootingSpeed>();
        _activeMegaProjectile = GetComponent<ActiveMegaProjectile>();

    }
    
    
    //A bunch of check for when an input is pressed / hover / released / ... 
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

