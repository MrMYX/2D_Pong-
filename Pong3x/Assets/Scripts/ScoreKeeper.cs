using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreKeeper : MonoBehaviour
{
    
    int leftScore = 0;
    int rightScore = 0;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    public int GetLeftScore()
    {
        return leftScore;
    }
    public int GetRightScore()
    {
        return rightScore;
    }
    public void IncreaseLeftScore()
    {
        leftScore++;
    }
    public void IncreaseRightScore()
    {
        rightScore++;
    }
    public void ResetScores()
    {
        leftScore = 0;
        rightScore = 0;
    }
    void FixedUpdate()
    { 
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();    
    }
}
