using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private Text scoreText;
	[SerializeField] private Text scoreNumber;
	[SerializeField] private GameObject gameOver;
	

	void Start()
	{
		gameOver.SetActive(false);
	}
	
	public void AddPoint()
	{
		var score = StateController.CurrentScore++;
		scoreText.text = score.ToString();
	}

	public void EndGame()
	{
		scoreNumber.text = scoreText.text;
		gameOver.SetActive(true);
	}
}
