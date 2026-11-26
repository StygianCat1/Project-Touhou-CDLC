using System.Collections.Generic;
using Script.Player.Capacity.Enum;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class CapacityWithImage
{
    //Ref to get name of the capacity
    public CapacityName name;
    //ref of the sprite of the capacity
    public Sprite sprite;
}


public class Capacity_GUI : MonoBehaviour
{
    //List of the capacity name with image associated
    [SerializeField] public List<CapacityWithImage> capacityWithImage;
    
    //Ref of active capacity name
    [SerializeField] public CapacityName activeCapacity;
    //ref of Image to put active capacity sprite
    [SerializeField] public Image activeCapacityImage;
    //Ref to the number of capacity usage
    [SerializeField] public TextMeshProUGUI activeCapacityText;
    
    //Ref of equipment capacity 1 name
    [SerializeField] public CapacityName equipmentCapacity1;
    //ref of Image to put equipment capacity sprite 1
    [SerializeField] public Image equipmentCapacity1Image;
    //Ref of equipment capacity 2 name
    [SerializeField] public CapacityName equipmentCapacity2;
    //ref of Image to put equipment capacity sprite 2
    [SerializeField] public Image equipmentCapacity2Image;
    
    //Ref of passive capacity 1 name
    [SerializeField] public CapacityName passiveCapacity1;
    //ref of Image to put passive capacity sprite 1
    [SerializeField] public Image passiveCapacity1Image;
    //Ref of passive capacity 2 name
    [SerializeField] public CapacityName passiveCapacity2;
    //ref of Image to put active passive sprite 2
    [SerializeField] public Image passiveCapacity2Image;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateTheCapacitySprite()
    {
        //Set all capacity with their sprite
        SetUpActiveCapacity();
        SetUpEquipmentCapacity();
        SetUpPassiveCapacity();
    }
    
    private void SetUpActiveCapacity()
    {
        //If capacity name is none than do nothing
        if (activeCapacity == CapacityName.None)
        {
            activeCapacityText.enabled = false;
        }
        //If there's a capacity name, check in the list
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            //Search for same name 
            if (activeCapacity == capacityWithImage[i].name)
            {
                //print(activeCapacity);
                //print(i);
                //If same name then put the sprite in the image
                activeCapacityImage.sprite = capacityWithImage[i].sprite;
            }
        }
    }

    private void SetUpEquipmentCapacity()
    {
        //Check in the list 
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            //Search for same name 
            if (equipmentCapacity1 == capacityWithImage[i].name)
            {
                //If same name then put the sprite in the image
                equipmentCapacity1Image.sprite = capacityWithImage[i].sprite;
            }
        }
        
        //Check in the list 
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            //Search for same name 
            if (equipmentCapacity2 == capacityWithImage[i].name)
            {
                //If same name then put the sprite in the image
                equipmentCapacity2Image.sprite = capacityWithImage[i].sprite;
            }
        }
    }

    private void SetUpPassiveCapacity()
    {
        //Check in the list 
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            //Search for same name 
            if (passiveCapacity1 == capacityWithImage[i].name)
            {
                //If same name then put the sprite in the image
                passiveCapacity1Image.sprite = capacityWithImage[i].sprite;
            }
        }
        
        //Check in the list 
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            //Search for same name 
            if (passiveCapacity2 == capacityWithImage[i].name)
            {
                //If same name then put the sprite in the image
                passiveCapacity2Image.sprite = capacityWithImage[i].sprite;
            }
        }
    }
}
