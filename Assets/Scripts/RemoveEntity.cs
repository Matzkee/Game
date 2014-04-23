using UnityEngine;
using System.Collections;

public class RemoveEntity : MonoBehaviour {
	public float lifetime;

	void Start()
	{
		Destroy (gameObject, lifetime);
	}
}
