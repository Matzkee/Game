using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public GUIText scoreText;
	public GUIText WaveText;
	public GUIText LifeCount;
	public GUIText gameOverText;
	public GUIText resetGameText;

	public float PlayerSpawnTime;
	public GameObject Player;
	public Transform PlayerSpawn;
	public GameObject Enemy;
	public Transform enemySpawn;
	private Vector3 spawnTrack = new Vector3(0.0f,0.0f,0.0f);
	public float spacingX = 20.0f;
	public float spacingZ = 20.0f;
	public float SpawnTime = 1.0f;
	public int enemyRows;
	public int enemyCols;
	public float WaveTimer = 5.0f;

	public bool PauseGame;

	private int Lives;
	private bool gameFinish;
	private bool resetGame;

	private int mainScore;
	private int waveCount;

	void Start()
	{
		Lives = 5;
		mainScore = 0;
		waveCount = 0;
		gameOverText.text = "";
		resetGameText.text = "";
		PauseGame = false;
		spawnTrack = enemySpawn.position;
		gameFinish = false;
		UpdateText();
		StartCoroutine (spawnEnemies ());
	}

	void Update()
	{
		//Pause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(PauseGame == true)
			{
				PauseGame = false;
			}
			else
			{
				PauseGame = true;
			}
		}
		if (PauseGame == true) 
		{
			Time.timeScale = 0.0f;
		}
		else
		{
			Time.timeScale = 1.0f;
		}

		//Reset the Game
		if(resetGame)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			else if(Input.GetKeyDown(KeyCode.M))
			{
				Application.LoadLevel(0);
			}
		}
	}


	void UpdateText()
	{
		scoreText.text = "Score: " + mainScore;
		WaveText.text = "Wave: " + waveCount;
		LifeCount.text = "Lives: " + Lives;
	}

	public void addToScore(int newScore)
	{
		mainScore += newScore;
		UpdateText ();
	}

	//in order to setup any kind of timer instead of void we have to use IEnumerator and instantiate it with StartCoroutine() function
	//then were able to use functions like WaitForSeconds.
	IEnumerator spawnEnemies()
	{
		while(true)
		{
			//Check for remaining enemies
			GameObject enemyRemaining = GameObject.FindWithTag("EnemyModel");
			if(enemyRemaining == null)
			{
				yield return new WaitForSeconds(WaveTimer);
				waveCount += 1;
				WaveText.text = "Wave: " + waveCount;
				for(int i = 0; i < enemyCols; i++)
				{
					for(int j = 0; j < enemyRows; j++)
					{
						yield return new WaitForSeconds(SpawnTime);
						Instantiate(Enemy,enemySpawn.position, enemySpawn.rotation);
						enemySpawn.position += new Vector3(spacingX,0.0f,0.0f);
					}
					enemySpawn.position += new Vector3(-(spacingX*enemyRows),0.0f,-spacingZ);
				}
			}
			enemySpawn.position = spawnTrack;
			yield return new WaitForSeconds(WaveTimer);
			if (gameFinish)
			{
				resetGameText.text = "Press 'R' to restart\n or 'M' to return to main menu";
				resetGame = true;
				break;
			}
		}
	}

	IEnumerator respawn()
	{
		yield return new WaitForSeconds (PlayerSpawnTime);
		Instantiate (Player, PlayerSpawn.position, PlayerSpawn.rotation);
	}

	public void GameOver(int removeLife)
	{
		Lives -= removeLife;
		LifeCount.text = "Lives: " + Lives;
		if (Lives == 0) 
		{
			gameFinish = true;
			gameOverText.text = "Game Over";
		}
		else
		{
			StartCoroutine(respawn());
		}
	}
}
