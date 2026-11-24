using System.Collections.Generic;
using Script.Player.Capacity.Enum;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class CapacityWithImage
{
    public CapacityName name;
    public Sprite sprite;
}


public class Capacity_GUI : MonoBehaviour
{
    [SerializeField] public List<CapacityWithImage> capacityWithImage;
    
    [SerializeField] public CapacityName activeCapacity;
    [SerializeField] public Image activeCapacityImage;
    [SerializeField] public TextMeshProUGUI activeCapacityText;
    
    
    [SerializeField] public CapacityName equipmentCapacity1;
    [SerializeField] public Image equipmentCapacity1Image;
    [SerializeField] public CapacityName equipmentCapacity2;
    [SerializeField] public Image equipmentCapacity2Image;
    
    [SerializeField] public CapacityName passiveCapacity1;
    [SerializeField] public Image passiveCapacity1Image;
    [SerializeField] public CapacityName passiveCapacity2;
    [SerializeField] public Image passiveCapacity2Image;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetUpActiveCapacity();
        SetUpEquipmentCapacity();
        SetUpPassiveCapacity();
    }

    private void SetUpActiveCapacity()
    {
        if (activeCapacity == CapacityName.None)
        {
            activeCapacityText.enabled = false;
        }
        
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            if (activeCapacity == capacityWithImage[i].name)
            {
                activeCapacityImage.sprite = capacityWithImage[i].sprite;
            }
        }
    }

    private void SetUpEquipmentCapacity()
    {
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            if (equipmentCapacity1 == capacityWithImage[i].name)
            {
                equipmentCapacity1Image.sprite = capacityWithImage[i].sprite;
            }
        }
        
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            if (equipmentCapacity2 == capacityWithImage[i].name)
            {
                equipmentCapacity2Image.sprite = capacityWithImage[i].sprite;
            }
        }
    }

    private void SetUpPassiveCapacity()
    {
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            if (passiveCapacity1 == capacityWithImage[i].name)
            {
                passiveCapacity1Image.sprite = capacityWithImage[i].sprite;
            }
        }
        
        for (int i = 0; i < capacityWithImage.Count; i++)
        {
            if (passiveCapacity2 == capacityWithImage[i].name)
            {
                passiveCapacity2Image.sprite = capacityWithImage[i].sprite;
            }
        }
        
    }
}
