using UnityEngine;
using System.Collections;

public class BoltVelocity : MonoBehaviour {

	public float speed;
	// Use this for initialization
	// We need to call it once since once the bolt spawn it travels at same speed
	void Start () {
		Vector3 boltSpeed = new Vector3 (0.0f, 0.0f, speed);
		rigidbody.velocity = boltSpeed;
	}

}
