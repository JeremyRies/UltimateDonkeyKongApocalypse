using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StateController.IsPaused = false;
		StateController.GameIsOver = false;
		SceneManager.LoadScene(1);
	}

}
