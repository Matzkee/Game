using UnityEngine;
using System.Collections;

public class PlayerDestroyed : MonoBehaviour {

	private Game gameControll;
	private int damage = 1;

	// Use this for initialization
	void Start () {
		//Look for Our Game script to allow us update the score which is located in GameControl
		GameObject gameCont = GameObject.FindWithTag ("GameController");
		if (gameCont != null)
		{
			//Get the Game Script
			gameControll = gameCont.GetComponent <Game>();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "EnemyBolt")
		{
			Debug.Log("Player Destroyed!");
			gameControll.GameOver(damage);

			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
