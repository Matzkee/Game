using UnityEngine;
using System.Collections;

public class EnemyBolt : MonoBehaviour {

	public float speed;

	// We need to call it once since once the bolt spawn it travels at same speed
	void Start () {
		Vector3 boltSpeed = new Vector3 (0.0f,0.0f,-speed);
		rigidbody.velocity = boltSpeed;
	}

}