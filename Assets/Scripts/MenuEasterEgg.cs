using UnityEngine;
using System.Collections;

public class MenuEasterEgg : MonoBehaviour {

	public GameObject Explosion;

	void OnMouseUp()
	{
		Instantiate (Explosion, transform.position - new Vector3(0.0f, 10.0f, 0.0f), transform.rotation);
		Destroy (gameObject);
	}
}
