using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats_GUI : MonoBehaviour
{
    //Text to put the number of power
    [SerializeField] public TextMeshProUGUI PowerText;
    //Slider to put the power
    [SerializeField] public Slider PowerSlider;
    //Text to put the number of graze
    [SerializeField] public TextMeshProUGUI GrazeText;
    //Text to put the number of point
    [SerializeField] public TextMeshProUGUI PointsText;


    //Update all stats (called by Stats)
    public void UpdateAllStats(int newPower, int maxPower, int newGraze, int newPoints)
    {
        UpdatePower(newPower, maxPower);
        UpdateGraze(newGraze);
        UpdatePoints(newPoints);
    }

    //Update the number of power 
    public void UpdatePower(int newPower, int maxPower)
    {
        //Set text to the number of power
        PowerText.text = newPower.ToString();
        //Set slider to the number of power
        PowerSlider.value = (float)newPower/(float)maxPower;
    }    
    
    //Update the number of graze
    public void UpdateGraze(int newGraze)
    {
        //Set text to the number of graze
        GrazeText.text = newGraze.ToString();
    }
    
    //Update the number of point
    public void UpdatePoints(int newPoints)
    {
        //Set text to the number of point
        PointsText.text = newPoints.ToString();
    }    
}
