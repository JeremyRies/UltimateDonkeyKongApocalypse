using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	private int score;
	[SerializeField] private Text scoreText;

	private void Start()
	{
		score = 0;
	}

	public void AddPoint()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
