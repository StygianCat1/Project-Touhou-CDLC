using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void EndPauseMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitGame(string mainMenuSceneName)
    {
        Application.LoadLevel(mainMenuSceneName);
    }
}
