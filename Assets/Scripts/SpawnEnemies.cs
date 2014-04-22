using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject Enemy;
	public Transform enemySpawn;
	public float spacingX = 20.0f;
	public float spacingZ = 20.0f;

	public int enemyRows;
	public int enemyCols;

	void Start()
	{
		spawnEnemies ();
	}

	void spawnEnemies()
	{
		for(int i = 0; i < enemyCols; i++)
		{
			for(int j = 0; j < enemyRows; j++)
			{
				Instantiate(Enemy,enemySpawn.position, enemySpawn.rotation);
				enemySpawn.position += new Vector3(spacingX,0.0f,0.0f);
			}
			enemySpawn.position += new Vector3(-(spacingX*enemyRows),0.0f,-spacingZ);
		}
	}

}
