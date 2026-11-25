using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    //Ref to pause UI
    [SerializeField] public GameObject pauseMenu;
    
    
    //Spawn pause UI
    public void Pause()
    {
        //Set Ui to active
        pauseMenu.SetActive(true);
    }
}
