using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
	public class Ninja : MonoBehaviour, IHittable, ITriggerUser
	{
		private NavMeshAgent _navMeshAgent;
		private static Stack<GameObject> _ninjaPoolStack;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			_navMeshAgent.SetDestination(GameManager.Odin.position);
		}

		public void TakeHit()
		{
			gameObject.SetActive(false);
		}

		private void OnDisable()
		{
			_ninjaPoolStack.Push(gameObject);
		}

		public void EnteredTrigger(Collider other)
		{
			other.GetComponent<IHittable>()?.TakeHit();
			gameObject.SetActive(false);
		}

		public static void SetNinjaPoolStack(Stack<GameObject> poolStack)
		{
			_ninjaPoolStack = poolStack;
		}
	}
}