using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] public Stats stats;
    [SerializeField] public ProblemSolver problemSolver;
    
    [SerializeField] public TextMeshProUGUI stageScoreText;
    [SerializeField] public TextMeshProUGUI powerScoreText;
    [SerializeField] public TextMeshProUGUI grazeScoreText;
    
    [SerializeField] public TextMeshProUGUI pointMultiplierText;
    
    [SerializeField] public TextMeshProUGUI BonusTotalText;
    [SerializeField] public TextMeshProUGUI TotalText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetStatsMultiplier();
        SetScoresText();
        Time.timeScale = 0f;
    }

    private void SetStatsMultiplier()
    {
        stageScoreText.text = (problemSolver.stage * 1000).ToString();
        powerScoreText.text = (stats.power * 100).ToString();
        grazeScoreText.text = (stats.graze * 10).ToString();
        pointMultiplierText.text = stats.points.ToString();
    }

    private void SetScoresText()
    {
        int scorebonus = (problemSolver.stage * 1000 + stats.power * 100 + stats.graze * 10) * stats.points;
        
        BonusTotalText.text = scorebonus.ToString();
        TotalText.text = (stats.score + scorebonus).ToString();
        stats.score += scorebonus;
    }
}
