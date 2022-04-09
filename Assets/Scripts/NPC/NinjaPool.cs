using System;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
	public class NinjaPool : MonoBehaviour
	{
		[SerializeField] private GameObject ninjaPrefab;
		[SerializeField] private Vector3 spawnRotation = new Vector3(10,0,0);
	
		private Quaternion _spawnQuaternion;
		private readonly Stack<GameObject> _ninjas = new Stack<GameObject>();

		private void Awake()
		{
			_spawnQuaternion = Quaternion.Euler(spawnRotation);
			Ninja.SetNinjaPoolStack(_ninjas);
		}

		public void SpawnNinja(Vector3 position)
		{
			GameObject spawnedNinja;
			try
			{
				spawnedNinja = _ninjas.Pop();
				spawnedNinja.SetActive(true);
				spawnedNinja.transform.position = position;
			}
			catch (InvalidOperationException)
			{
				spawnedNinja = Instantiate(ninjaPrefab, position, _spawnQuaternion);
			}
		}
	}
}