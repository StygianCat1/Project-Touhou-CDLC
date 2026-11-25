using System;
using Script.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    //Ref to players input
    private PlayerInputs _playerInputs;
    //Ref to the primary attack
    private PrimaryAttack _primaryAttackRef;
    //Ref to the secondary attack
    private SecondaryAttack _secondaryAttackRef;
    //ref to animator
    private Animator animator;
    
    //Character kit choice 
    [SerializeField] public KitChoosed characterKit;
    //Muzzle of the character for when he attack, spawn projectile from there
    [SerializeField] public GameObject primaryAttackMuzzle;
    [SerializeField] public GameObject secondaryAttackMuzzle1;
    [SerializeField] public GameObject secondaryAttackMuzzle2;
    [SerializeField] public GameObject secondaryAttackMuzzle3;
    [SerializeField] public GameObject secondaryAttackMuzzle4;
    [SerializeField] public GameObject secondaryAttackMuzzle5;
    //Boost of the attack speedd
    [SerializeField] public float attackSpeedBoostMultiplier = 1f;
    
    private void Start()
    {
        //Reference the component
        _playerInputs = GetComponent<PlayerInputs>();
        _primaryAttackRef = GetComponent<PrimaryAttack>();
        _secondaryAttackRef = GetComponent<SecondaryAttack>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        Shot();
    }

    public void Shot()
    {
        //Check if has shot
        if (_playerInputs.shotInput)
        {
            //Check which kit the character use
            if (characterKit == KitChoosed.FirstKit)
            {
                //Use the first kit
                UseFirstKit();
            }
            else
            {
                //Use the second kit
                UseSecondKit();
            }
        }
    }

    private void UseFirstKit()
    { 
        //Reference for the primary attack and its muzzle
        _primaryAttackRef.ShootPrimaryAttack1(primaryAttackMuzzle); 
        //Reference for the secondary attack and its muzzles
        _secondaryAttackRef.ShootSecondaryAttack1(secondaryAttackMuzzle1, secondaryAttackMuzzle2, secondaryAttackMuzzle3, secondaryAttackMuzzle4, secondaryAttackMuzzle5);
    }

    private void UseSecondKit()
    { 
        //Reference for the primary attack and its muzzle
        _primaryAttackRef.ShootPrimaryAttack2(primaryAttackMuzzle); 
        //Reference for the secondary attack and its muzzles
        _secondaryAttackRef.ShootSecondaryAttack2(secondaryAttackMuzzle1, secondaryAttackMuzzle2, secondaryAttackMuzzle3, secondaryAttackMuzzle4, secondaryAttackMuzzle5);
    }


    //Used for when slow / focus mode is activated the animation make the second attack muzzle move
    public void MoveSecondaryAttackSocketForFocus(bool focus)
    {
        //Set value in animator for the muzzle movement
        animator.SetBool("Focus", focus);
    }
}
