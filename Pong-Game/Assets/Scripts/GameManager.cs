using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    public bool isSinglePlayer = false;
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2){ scoreKeeper = FindObjectOfType<ScoreKeeper>(); }
    }
    public void StartSinglePlayer()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2){ scoreKeeper.ResetScores(); }
        SceneManager.LoadScene(1);
        if(!isSinglePlayer){ isSinglePlayer = true; }
    }
    public void StartDoublePlayer()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2){ scoreKeeper.ResetScores(); }
        SceneManager.LoadScene(2);
        if(isSinglePlayer){ isSinglePlayer = false; }
    }

    public void RestartGame()
    {
        if (isSinglePlayer)
        {
            StartSinglePlayer();
        }
        else if (!isSinglePlayer)
        {
            StartDoublePlayer();
        }
    }
    public void GoGameOver()
    {
        if (isSinglePlayer)
        {
            SceneManager.LoadScene(3);
        }
        else if (!isSinglePlayer)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    void Update()
    {
        EndGame();
    }
    public void EndGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (scoreKeeper.GetLeftScore() == 3 || scoreKeeper.GetRightScore() == 3)
            {
                GoGameOver();
            }
        }
    }
}
