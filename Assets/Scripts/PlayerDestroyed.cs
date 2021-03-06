﻿using UnityEngine;
using System.Collections;

public class PlayerDestroyed : MonoBehaviour {

	private Game gameControll;
	private int damage = 1;

	public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
		//Look for Our Game script to allow us update lives
		GameObject gameCont = GameObject.FindWithTag ("GameController");
		if (gameCont != null)
		{
			//Get the Game Script
			gameControll = gameCont.GetComponent <Game>();
		}
	}
	//Remove 1 life whenever player hits enemy bolt
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "EnemyBolt")
		{
			gameControll.GameOver(damage);
			Instantiate(playerExplosion, transform.position, transform.rotation);
			audio.Play();
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
