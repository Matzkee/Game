using UnityEngine;
using System.Collections;

public class VoidDestroy : MonoBehaviour 
{
	//Simple script to destroy any entities that touch our box collider
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
