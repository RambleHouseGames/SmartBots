﻿using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour 
{
	[SerializeField]
	private PlayField playField;

	public float Energy;

	[SerializeField]
	private float EnergyTransferRate;

	void Update()
	{
		gameObject.GetComponent<Renderer>().material.color = new Color(Energy / 3f, Energy / 3f, Energy / 3f);
	}

	public float Eat()
	{
		if(Energy < EnergyTransferRate * Time.deltaTime)
		{
			float finalEnergy = Energy;
			die ();
			return finalEnergy;
		}
		Energy -= EnergyTransferRate * Time.deltaTime;
		return EnergyTransferRate * Time.deltaTime;
	}

	private void die()
	{
		Vector2 randomPosition = playField.GetRandomPosition();
		transform.position = new Vector3(randomPosition.x, 0, randomPosition.y);
		Energy = 3f;
	}
}
