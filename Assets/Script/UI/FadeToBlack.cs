using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] public string levelName;
    [SerializeField] private Image fadeScreen;
    
    private float fadeTime;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(ChangeScene), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        fadeTime += Time.unscaledDeltaTime;
        fadeScreen.color = new Color(0, 0, 0, Mathf.Clamp(fadeTime, 0f, 100));   
    }
    
    void ChangeScene()
    {
        print("stop");
        SceneManager.LoadScene(levelName);
    }
}
