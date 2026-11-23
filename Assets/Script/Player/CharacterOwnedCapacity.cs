using System;
using System.Collections.Generic;
using Script.Player.Capacity.Enum;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Capacity
{
    public CapacityName name;
    public CapacityType type;
    public MonoBehaviour script;
}


public class CharacterOwnedCapacity : MonoBehaviour
{
    [SerializeField] public List<Capacity> capacitiesList;
    
    [SerializeField] public CapacityName activeCapacity;
    
    [SerializeField] public CapacityName equipmentCapacity1;
    [SerializeField] public CapacityName equipmentCapacity2;
    
    [SerializeField] public CapacityName passiveCapacity1;
    [SerializeField] public CapacityName passiveCapacity2;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetActiveAbility();
        SetEquipmentAbility();
        SetpassiveAbility();
    }
    
    
    private void SetActiveAbility()
    {
        if (activeCapacity == CapacityName.None)
        {
            print("there is not a active capacity");
            return;
        }

        for (int i = 0; i < capacitiesList.Count; i++)
        {
            if (capacitiesList[i].name == activeCapacity && capacitiesList[i].type == CapacityType.Active)
            {
                capacitiesList[i].script.enabled = true;
            }
        }
    }
    
    private void SetEquipmentAbility()
    {
        if (equipmentCapacity1 != CapacityName.None)
        {
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                if (capacitiesList[i].name == equipmentCapacity1 && capacitiesList[i].type == CapacityType.Equipment)
                {
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
        
        if (equipmentCapacity2 != CapacityName.None)
        {
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                if (capacitiesList[i].name == equipmentCapacity2 && capacitiesList[i].type == CapacityType.Equipment)
                {
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
        
    }
    
    private void SetpassiveAbility()
    {
        if (passiveCapacity1 != CapacityName.None)
        {
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                if (capacitiesList[i].name == passiveCapacity1 && (capacitiesList[i].type == CapacityType.PassiveMultipleUse || capacitiesList[i].type == CapacityType.PassiveSingleUse))
                {
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
        
        if (passiveCapacity2 != CapacityName.None)
        {
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                if (capacitiesList[i].name == passiveCapacity2 && (capacitiesList[i].type == CapacityType.PassiveMultipleUse || capacitiesList[i].type == CapacityType.PassiveSingleUse))
                {
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
    }
}
