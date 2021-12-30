using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    private Scores ScoresScript;
    public GameObject GameOverPanel; 
    private int bestScore;

    private void Start()
    {
        ScoresScript = GetComponent<Scores>();
        
    }
    public void GameOverFunc()
    {
        bestScore= ScoresScript.GetBestScore();
        ScoresScript.isAliveCheck();
        PlayerPrefs.SetInt("bestScoreKey", bestScore);
        GameOverPanel.SetActive(true);
        //Camera.main.GetComponentInParent<Player>().SetAcceleration (0);   
    }

    public void NewGameFunc()
    {
        //GameOverPanel.SetActive(false);
        //ScoresScript.SetCurrentScore(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
