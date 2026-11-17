using System;
using Script.Player;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private PrimaryAttack primaryAttackRef;
    private SecondaryAttack secondaryAttackRef;

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
        primaryAttackRef = GetComponent<PrimaryAttack>();
        secondaryAttackRef = GetComponent<SecondaryAttack>();
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
            primaryAttackRef.ShootPrimaryAttack1(primaryAttackMuzzle);
            secondaryAttackRef.ShootSecondaryAttack1(secondaryAttackMuzzle1, secondaryAttackMuzzle2, secondaryAttackMuzzle3, secondaryAttackMuzzle4, secondaryAttackMuzzle5);
        }
    }

    private void UseSecondKit()
    {
        if (characterKit == KitChoosed.SecondKit)
        {
            primaryAttackRef.ShootPrimaryAttack2(primaryAttackMuzzle);
            secondaryAttackRef.ShootSecondaryAttack2(secondaryAttackMuzzle1, secondaryAttackMuzzle2, secondaryAttackMuzzle3, secondaryAttackMuzzle4, secondaryAttackMuzzle5);
        }
    }
}
