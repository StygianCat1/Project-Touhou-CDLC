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
    //Name of the capacity
    public CapacityName name;
    //Type of the capacity
    public CapacityType type;
    //Script linked to the capacity
    public MonoBehaviour script;
}


public class CharacterOwnedCapacity : MonoBehaviour
{
    //Ref to GUI
    private GameObject gUI;
    
    //List of all the capacities and their script
    [SerializeField] public List<Capacity> capacitiesList;
    
    //Active capacity ref
    [SerializeField] public CapacityName activeCapacity;
    
    //Equipment capacity ref
    [SerializeField] public CapacityName equipmentCapacity1;
    [SerializeField] public CapacityName equipmentCapacity2;
    
    //Passive capacity ref
    [SerializeField] public CapacityName passiveCapacity1;
    [SerializeField] public CapacityName passiveCapacity2;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Set everything at the beginning
        SetActiveAbility();
        SetEquipmentAbility();
        SetpassiveAbility();
        SetGUI();
    }
    
    
    private void SetActiveAbility()
    {
        //Check if there's an active capacity
        if (activeCapacity == CapacityName.None)
        {
            print("there is not a active capacity");
            return;
        }
        //If one then check what it is
        for (int i = 0; i < capacitiesList.Count; i++)
        {
            // Check the name and the type
            if (capacitiesList[i].name == activeCapacity && capacitiesList[i].type == CapacityType.Active)
            {
                //if both are the same then activate the capacity
                capacitiesList[i].script.enabled = true;
            }
        }
    }
    
    private void SetEquipmentAbility()
    {
        //Check if there's a equipment capacity in this slot
        if (equipmentCapacity1 != CapacityName.None)
        {
            //If one then check what it is
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                // Check the name and the type
                if (capacitiesList[i].name == equipmentCapacity1 && capacitiesList[i].type == CapacityType.Equipment)
                {
                    //if both are the same then activate the capacity
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
        
        //Check if there's an equipment capacity in this slot
        if (equipmentCapacity2 != CapacityName.None)
        {
            //If one then check what it is
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                // Check the name and the type
                if (capacitiesList[i].name == equipmentCapacity2 && capacitiesList[i].type == CapacityType.Equipment)
                {
                    //if both are the same then activate the capacity
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
        
    }
    
    private void SetpassiveAbility()
    {
        //Check if there's a passive capacity in this slot
        if (passiveCapacity1 != CapacityName.None)
        {
            //If one then check what it is
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                // Check the name and the type
                if (capacitiesList[i].name == passiveCapacity1 && (capacitiesList[i].type == CapacityType.PassiveMultipleUse || capacitiesList[i].type == CapacityType.PassiveSingleUse))
                {
                    //if both are the same then activate the capacity
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
        
        //Check if there's a passive capacity in this slot
        if (passiveCapacity2 != CapacityName.None)
        {
            //If one then check what it is
            for (int i = 0; i < capacitiesList.Count; i++)
            {
                // Check the name and the type
                if (capacitiesList[i].name == passiveCapacity2 && (capacitiesList[i].type == CapacityType.PassiveMultipleUse || capacitiesList[i].type == CapacityType.PassiveSingleUse))
                {
                    //if both are the same then activate the capacity
                    capacitiesList[i].script.enabled = true;
                }
            }
        }
    }

    //Set Capacities icon in GUI
    private void SetGUI()
    {
        //Reference to GameObject / canvas
        gUI = GameObject.FindGameObjectWithTag("GUI");
        //Give the ref to the GUI
        gUI.GetComponent<Capacity_GUI>().activeCapacity = activeCapacity;
        gUI.GetComponent<Capacity_GUI>().equipmentCapacity1 = equipmentCapacity1;
        gUI.GetComponent<Capacity_GUI>().equipmentCapacity2 = equipmentCapacity2;
        gUI.GetComponent<Capacity_GUI>().passiveCapacity1 = passiveCapacity1;
        gUI.GetComponent<Capacity_GUI>().passiveCapacity2 = passiveCapacity2;
    }
}
