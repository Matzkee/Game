using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public bool isExit = false;

	void OnMouseEnter()
	{
		renderer.material.color = Color.cyan;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}

	void OnMouseUp()
	{
		if(isExit == true)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel (1);
		}
	}
}
