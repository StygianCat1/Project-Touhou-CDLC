using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
