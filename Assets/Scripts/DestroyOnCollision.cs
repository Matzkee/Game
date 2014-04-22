using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PlayerBolt") {
			Debug.Log("Hit the enemy!");

			Destroy(other.gameObject);
			Destroy (gameObject);
				}

	}
}
