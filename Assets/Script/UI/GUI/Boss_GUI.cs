using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss_GUI : MonoBehaviour
{
    
    [SerializeField] public Slider bossHealthSlider;
    [SerializeField] public TextMeshProUGUI bossLiveText;
    
    [SerializeField] public GameObject box; 

    public void ShowUI()
    {
        box.SetActive(true);
    }

    public void HideUI()
    {
        box.SetActive(false);
    }
    
    public void UpdateAll(float health,float maxHealth, int live)
    {
        bossHealthSlider.value = 1 - health / maxHealth; ;
        bossLiveText.text = live.ToString();
    } 
}
