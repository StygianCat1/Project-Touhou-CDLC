using System;
using Script.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private PrimaryAttack _primaryAttackRef;
    private SecondaryAttack _secondaryAttackRef;
    private Animator animator;

    //[HideInInspector] 
    [SerializeField] public KitChoosed characterKit;
    [SerializeField] public GameObject primaryAttackMuzzle;
    [SerializeField] public GameObject secondaryAttackMuzzle1;
    [SerializeField] public GameObject secondaryAttackMuzzle2;
    [SerializeField] public GameObject secondaryAttackMuzzle3;
    [SerializeField] public GameObject secondaryAttackMuzzle4;
    [SerializeField] public GameObject secondaryAttackMuzzle5;
    
    private void Start()
    {
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
        if (_playerInputs.shotInput)
        {
            if (characterKit == KitChoosed.FirstKit)
            {
                UseFirstKit();
            }
            else
            {
                UseSecondKit();
            }
        }
    }

    private void UseFirstKit()
    {
        if (characterKit == KitChoosed.FirstKit)
        {
            _primaryAttackRef.ShootPrimaryAttack1(primaryAttackMuzzle);
            _secondaryAttackRef.ShootSecondaryAttack1(secondaryAttackMuzzle1, secondaryAttackMuzzle2, secondaryAttackMuzzle3, secondaryAttackMuzzle4, secondaryAttackMuzzle5);
        }
    }

    private void UseSecondKit()
    {
        if (characterKit == KitChoosed.SecondKit)
        {
            _primaryAttackRef.ShootPrimaryAttack2(primaryAttackMuzzle);
            _secondaryAttackRef.ShootSecondaryAttack2(secondaryAttackMuzzle1, secondaryAttackMuzzle2, secondaryAttackMuzzle3, secondaryAttackMuzzle4, secondaryAttackMuzzle5);
        }
    }


    public void MoveSecondaryAttackSocketForFocus(bool focus)
    {
        animator.SetBool("Focus", focus);
    }
}
