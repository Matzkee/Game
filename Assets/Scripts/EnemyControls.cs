using UnityEngine;
using System.Collections;

public class EnemyControls : MonoBehaviour {

	public float minX;
	public float maxX;

	public GameObject enemyBolt;
	public Transform boltPos;

	public float difficulty = 0.09f;
	public float enemyFireRate = 2.0f;
	private float lastTimeFired = 0.0f;

	void Start()
	{
		minX = transform.position.x - 10;
		maxX = transform.position.x + 10;
	}

	void Update()
	{
		transform.position = new Vector3 (Mathf.PingPong(Time.time*4,maxX-minX)+minX, transform.position.y, transform.position.z);

		if(Random.value > difficulty)
		{
			if(Time.time > (enemyFireRate + lastTimeFired))
			{
				Instantiate(enemyBolt, boltPos.position, boltPos.rotation);
				lastTimeFired = Time.time;
			}
		}
	}

}
