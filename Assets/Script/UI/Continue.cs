using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    [SerializeField] public Stats stats;
    [SerializeField] public TextMeshProUGUI nbrOfLifeText;
    [SerializeField] public GameObject fadeToBlackTransition;

    private void OnEnable()
    {
        
        nbrOfLifeText.text = stats.continueNbr.ToString();
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        stats.continueNbr -= 1;
        stats.health = 3;
        stats.bomb = 3;
        stats.power = 0;
        stats.SpawnContinueCollectible();
        
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        for (int i = 0; i < projectiles.Length; i++)
        {
            Destroy(projectiles[i]);
        }
    }

    public void GoBack(string SceneName)
    {
        fadeToBlackTransition.GetComponent<FadeToBlack>().levelName = SceneName;
        fadeToBlackTransition.SetActive(true);
    }
}
