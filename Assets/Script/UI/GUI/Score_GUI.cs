using UnityEngine;
using TMPro;

public class Score_GUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI hiScoreText;
    [SerializeField] public TextMeshProUGUI scoreText;

    public void UpdateAllScores(int score,int hiScore)
    {
        ChangeScore(score);
        ChangeHiScore(hiScore);
    }

    public void ChangeScore(int score)
    {
        string scoreString = new string("");
        for (int i = 0; i < 8 - score.ToString().Length; i++)
        {
            scoreString += "0";
        }
        scoreText.text = scoreString + score;
    }

    public void ChangeHiScore(int score)
    {
        string hiScoreString = new string("");
        for (int i = 0; i < 8 - score.ToString().Length; i++)
        {
            hiScoreString += "0";
        }
        hiScoreText.text = hiScoreString + score;
    }
}
