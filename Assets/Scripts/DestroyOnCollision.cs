using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public int bugScore;
	private Game gameControll;

	void Start()
	{
		//Look for Our Game script to allow us update the score which is located in Game script
		GameObject gameContObject = GameObject.FindWithTag ("GameController");
		if (gameContObject != null)
		{
			gameControll = gameContObject.GetComponent <Game>();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PlayerBolt")
		{
			Debug.Log("Hit the enemy!");

			gameControll.addToScore(bugScore);

			Destroy(other.gameObject);
			Destroy (gameObject);
		}

	}
}
