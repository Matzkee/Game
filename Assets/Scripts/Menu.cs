using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//a bool is used just so i can use the same script for other text objects
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
