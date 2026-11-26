using System;
using Script.Player.Capacity.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        //Reset everything, just to be cautious 
        Save.activeCapacityName = CapacityName.None;
        Save.equipmentCapacity1Name = CapacityName.None;
        Save.equipmentCapacity2Name = CapacityName.None;
        Save.passiveCapacity1Name = CapacityName.None;
        Save.passiveCapacity2Name = CapacityName.None;
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CreateOtherUI(GameObject ui)
    {
        ui.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
