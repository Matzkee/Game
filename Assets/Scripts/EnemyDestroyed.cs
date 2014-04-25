using UnityEngine;
using System.Collections;

public class EnemyDestroyed : MonoBehaviour {

	public int bugScore;
	private Game gameControll;

	public GameObject explosionEffect;

	void Start()
	{
		//Look for Our Game script to allow us update the score which is located in GameControl
		GameObject gameCont = GameObject.FindWithTag ("GameController");
		if (gameCont != null)
		{
			//Get the Game Script
			gameControll = gameCont.GetComponent <Game>();
		}
	}

	//Collision detection
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PlayerBolt")
		{
			gameControll.addToScore(bugScore);

			Instantiate(explosionEffect, transform.position, transform.rotation);

			Destroy(other.gameObject);
			Destroy (gameObject);
		}

	}
}
