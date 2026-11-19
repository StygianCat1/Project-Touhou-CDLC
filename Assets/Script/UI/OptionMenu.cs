using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void CreateOtherUI(GameObject ui)
    {
        ui.SetActive(true);
        gameObject.SetActive(false);
    }
}
