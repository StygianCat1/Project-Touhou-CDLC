using UnityEngine;

public class Credits : MonoBehaviour
{
    public void CreateOtherUI(GameObject ui)
    {
        ui.SetActive(true);
        gameObject.SetActive(false);
    }
}
