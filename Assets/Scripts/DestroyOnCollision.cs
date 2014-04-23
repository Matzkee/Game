using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public int bugScore;
	private Game gameControll;

	public GameObject explosionEffect;

	void Start()
	{
		//Look for Our Game script to allow us update the score which is located in GameControl
		GameObject gameCont = GameObject.FindWithTag ("GameController");
		if (gameCont != null)
		{
			gameControll = gameCont.GetComponent <Game>();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PlayerBolt")
		{
			Debug.Log("Hit the enemy!");
			gameControll.addToScore(bugScore);

			Instantiate(explosionEffect, transform.position, transform.rotation);

			Destroy(other.gameObject);
			Destroy (gameObject);
		}

	}
}
