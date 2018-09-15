using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private Text scoreText;

	public void AddPoint()
	{
		var score = StateController.CurrentScore++;
		scoreText.text = score.ToString();
	}
}
