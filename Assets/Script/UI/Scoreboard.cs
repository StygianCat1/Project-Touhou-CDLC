using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    //Ref to Stats
    [SerializeField] public Stats stats;
    //Ref to problem Solver
    [SerializeField] public ProblemSolver problemSolver;
    
    //Name of the next scene 
    [SerializeField] public string nextSceneName;
    
    //SCore of the stage
    [SerializeField] public TextMeshProUGUI stageScoreText;
    //Score of the power
    [SerializeField] public TextMeshProUGUI powerScoreText;
    //Score of the graze
    [SerializeField] public TextMeshProUGUI grazeScoreText;
    
    //Multiplier of the point
    [SerializeField] public TextMeshProUGUI pointMultiplierText;
    
    //Total of the bonus score
    [SerializeField] public TextMeshProUGUI BonusTotalText;
    //Total score
    [SerializeField] public TextMeshProUGUI TotalText;

    //Timer to switch to next stage
    private float timerToNextStage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set all  
        SetStatsMultiplier();
        SetScoresText();
        //Begin timer to change scene
        BeginTimer();
        //Stop time 
        Time.timeScale = 0f;
    }

    //Set all stats  in scoreboard
    private void SetStatsMultiplier()
    {
        //Set all score stats with their multiplier
        stageScoreText.text = (problemSolver.stage * 1000).ToString();
        powerScoreText.text = (stats.power * 100).ToString();
        grazeScoreText.text = (stats.graze * 10).ToString();
        //Set point as multiplier
        pointMultiplierText.text = stats.points.ToString();
    }

    private void SetScoresText()
    {
        //Multiply all into score bonus
        int scorebonus = (problemSolver.stage * 1000 + stats.power * 100 + stats.graze * 10) * stats.points;
        
        //Set score bonus in text
        BonusTotalText.text = scorebonus.ToString();
        //Add score bonus to score & set score text
        stats.score += scorebonus;
        TotalText.text = stats.score.ToString();
        
    }

    //Timer to switch to next stage
    private void BeginTimer()
    {
        //Use timer to move to next stage
        if (timerToNextStage <= 10f)
        {
            timerToNextStage += Time.unscaledDeltaTime;
            return;
        }
        MoveToNextStage();
    }

    //Allow change to next stage
    public void MoveToNextStage()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    
    
    
}
