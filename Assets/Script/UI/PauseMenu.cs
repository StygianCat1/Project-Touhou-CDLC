using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        print("test");
        Time.timeScale = 0;
    }

    public void EndPauseMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame(string mainMenuSceneName)
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
