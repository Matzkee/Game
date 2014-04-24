using UnityEngine;
using System.Collections;

public class MenuPlayerHover : MonoBehaviour {

	public float maxHover;
	public float minHover;

	public float minRotationY;
	public float maxRotationY;
	public float minRotationX;
	public float maxRotationX;
	public float minRotationZ;
	public float maxRotationZ;


	void Update()
	{
		transform.position = new Vector3 (transform.position.x, 
		                                  Mathf.PingPong(Time.time,maxHover-minHover)+minHover, 
		                                  transform.position.z);
		transform.rotation = Quaternion.Euler (Mathf.PingPong (Time.time, maxRotationX - minRotationX) + minRotationX, 
		                                       Mathf.PingPong (Time.time, maxRotationY - minRotationY) + minRotationY, 
		                                       Mathf.PingPong (Time.time, maxRotationZ - minRotationZ) + minRotationZ);
	}
}
