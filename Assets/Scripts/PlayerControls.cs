using UnityEngine;
using System.Collections;
[System.Serializable]
public class BoxEdges
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControls : MonoBehaviour {

	public float speed = 10.0f;
	public BoxEdges edges;

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
	}
}
