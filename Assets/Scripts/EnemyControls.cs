using UnityEngine;
using System.Collections;

public class EnemyControls : MonoBehaviour {

	public float minX;
	public float maxX;


	void Start()
	{
		minX = transform.position.x - 10;
		maxX = transform.position.x + 10;
	}

	void Update()
	{
		transform.position = new Vector3 (Mathf.PingPong(Time.time*4,maxX-minX)+minX, transform.position.y, transform.position.z);
	}

}
