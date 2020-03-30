/*
 * Jake Buri
 * RPSGame.cs
 * Assignment 5
 * Factory to create either a rock, paper, or scissor
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSFactory : MonoBehaviour
{
	public GameObject RockPrefab;
	public GameObject PaperPrefab;
	public GameObject ScissorsPrefab;

	private GameObject objectToSpawn;

	public GameObject CreateRPS(string type)
	{
		objectToSpawn = null;

		if (type.Equals("Rock"))
		{
			objectToSpawn = RockPrefab;

			//If there is not already a Rock script attached to the prefab, attach one
			if (objectToSpawn.GetComponent<Rock>() == null)
			{
				objectToSpawn.AddComponent<Rock>();
			}
		}
		else if (type.Equals("Paper"))
		{
			objectToSpawn = PaperPrefab;

			//If there is not already a Paper script attached to the prefab, attach one
			if (objectToSpawn.GetComponent<Paper>() == null)
			{
				objectToSpawn.AddComponent<Paper>();
			}

		}
		else if (type.Equals("Scissors"))
		{
			objectToSpawn = ScissorsPrefab;

			//If there is not already a Scissors script attached to the prefab, attach one
			if (objectToSpawn.GetComponent<Scissors>() == null)
			{
				objectToSpawn.AddComponent<Scissors>();
			}

		}

		Debug.Log("Factory sending: " + objectToSpawn);
		return objectToSpawn;
	}

}
