using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public GUIText scoreText;

	private int mainScore;

	void Start()
	{
		UpdateScore();
	}

	void Update()
	{
		UpdateScore ();
	}


	void UpdateScore()
	{
		scoreText.text = "Score: " + mainScore;
	}

	public void addToScore(int newScore)
	{
		mainScore += newScore;
	}
}
