using UnityEngine;
using TMPro;

public class Score_GUI : MonoBehaviour
{
    //Text for the high score
    [SerializeField] public TextMeshProUGUI hiScoreText;
    //Text for the score
    [SerializeField] public TextMeshProUGUI scoreText;

    
    //Update all scores (called by Stats)
    public void UpdateAllScores(int score,int hiScore)
    {
        ChangeScore(score);
        ChangeHiScore(hiScore);
    }

    //Change score
    public void ChangeScore(int score)
    {
        //Create string with nothing in it
        string scoreString = new string("");
        //For the size of the score string - stats score length of the string
        for (int i = 0; i < 8 - score.ToString().Length; i++)
        {
            //Add 0 to the string
            scoreString += "0";
        }
        //Make the two string fuse
        scoreText.text = scoreString + score;
    }

    //Change high score
    public void ChangeHiScore(int score)
    {
        //Create string with nothing in it
        string hiScoreString = new string("");
        //For the size of the hiScore string - stats hiScore length of the string
        for (int i = 0; i < 8 - score.ToString().Length; i++)
        {
            //Add 0 to the string
            hiScoreString += "0";
        }
        //Make the two string fuse
        hiScoreText.text = hiScoreString + score;
    }
}