using UnityEngine;
using System.Collections;
[System.Serializable]
public class BoxEdges
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControls : MonoBehaviour {

	private bool readyToFire = true;
	private float lastTimeFired = 0.0f;
	public float tilt = 0.0f;

	public GameObject playerBolt;
	public Transform boltPos;
	public float speed = 10.0f;
	public float fireRate = 1.0f;
	public BoxEdges edges;

	void Update()
	{
		if ((Input.GetButton ("Fire1")) && (readyToFire)) {
			fire();
				}
	}

	void FixedUpdate () {
		float xPos = Input.GetAxis("Horizontal");
		float yPos = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (xPos, 0.0f, yPos);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 
		(
			Mathf.Clamp (rigidbody.position.x, edges.xMin, edges.xMax), // limit x axis
			0.0f, 
			Mathf.Clamp (rigidbody.position.z, edges.zMin, edges.zMax) // limit z axis
		);
		rigidbody.rotation = Quaternion.Euler (0.0f,0.0f,rigidbody.velocity.x * -tilt);
	}

	void fire()
	{
		if(Time.time > (fireRate + lastTimeFired))
		{
			Instantiate (playerBolt, boltPos.position, boltPos.rotation);
			audio.Play();
			lastTimeFired = Time.time;
		}
	}
}
