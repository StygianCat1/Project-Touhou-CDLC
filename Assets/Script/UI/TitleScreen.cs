using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void CreateOtherUI(GameObject ui)
    {
        ui.SetActive(true);
        gameObject.SetActive(false);
    }
}
