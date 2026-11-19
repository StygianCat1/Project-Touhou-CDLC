using UnityEngine;

public class Mapping : MonoBehaviour
{
    public void CreateOtherUI(GameObject ui)
    {
        ui.SetActive(true);
        gameObject.SetActive(false);
    }
}
