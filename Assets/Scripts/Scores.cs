using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
	private bool isPlayerAlive;

	public GameObject player;

	public Text currentdScoreTxt;
	public Text bestScoreTxt;
	public Text asteroidScoreTxt;


	private int currentScore=0;
	private int bestScore=0;
	private int asteroidCount = 0;

	private int scoreAcceleration = 1;

	void Start()
	{
		InvokeRepeating("permanentInceaceScore", 0, 1);
		Invoke("isAliveCheck", 0f);
		bestScore=PlayerPrefs.GetInt("bestScoreKey");
		bestScoreTxt.text = bestScore.ToString();
		
	}

	public void IncreaceScore()
	{
	
		if(isPlayerAlive)
		{
			currentScore += 5;
			asteroidCount += 1;
		    asteroidScoreTxt.text = asteroidCount.ToString();
			Debug.Log("Score:" + currentScore);
		}
	}


	private void permanentInceaceScore()
    {

		if (isPlayerAlive)
		{
			currentScore += 1*scoreAcceleration;// МЕНЯТЬ НА +2 когда acceleration =2
			currentdScoreTxt.text = currentScore.ToString();
		}
		if (currentScore > bestScore)
		{
			bestScore = currentScore;
			bestScoreTxt.text = bestScore.ToString();
		}
	}

	public void isAliveCheck()
    {
		isPlayerAlive = InputManager.Instance.isPlayerAlive();
	}

	public int GetBestScore()
    {
		return bestScore;
    }

	public void SetCurrentScore(int curSc)
    {
		currentScore = curSc;
    }
	public void SetScoreAcceleration(int scAccceler)
    {
		scoreAcceleration = scAccceler;
    }


}

