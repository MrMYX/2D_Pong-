using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isSinglePlayer;
    public TextMeshProUGUI GameOverScore;
    ScoreKeeper scoreKeeper;
    public void StartSinglePlayer()
    {
        scoreKeeper.ResetScores();
        SceneManager.LoadScene(1);
        isSinglePlayer = true;
    }
    public void StartDoublePlayer()
    {
        scoreKeeper.ResetScores();
        SceneManager.LoadScene(2);
        isSinglePlayer = false;
    }
    public void GoGameOver()
    {
        if(isSinglePlayer)
        {
            SceneManager.LoadScene(3);
        }
        else if(!isSinglePlayer)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Update()
    {
        EndGame();
    }
    public void EndGame()
    {
        if(scoreKeeper.GetLeftScore() == 3 || scoreKeeper.GetRightScore() == 3)
        {
            GoGameOver();
        }
    }
}
