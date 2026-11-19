using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats_GUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI PowerText;
    [SerializeField] public Slider PowerSlider;
    [SerializeField] public TextMeshProUGUI GrazeText;
    [SerializeField] public TextMeshProUGUI PointsText;


    public void UpdateAllStats(int newPower, int maxPower, int newGraze, int newPoints)
    {
        UpdatePower(newPower, maxPower);
        UpdateGraze(newGraze);
        UpdatePoints(newPoints);
    }

    public void UpdatePower(int newPower, int maxPower)
    {
        PowerText.text = newPower.ToString();
        PowerSlider.value = newPower/maxPower;
    }    
    public void UpdateGraze(int newGraze)
    {
        GrazeText.text = newGraze.ToString();
    }
    public void UpdatePoints(int newPoints)
    {
        PointsText.text = newPoints.ToString();
    }    
}
