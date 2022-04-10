using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
	public class Ninja : MonoBehaviour, IHittable
	{
		private NavMeshAgent _navMeshAgent;
		private static Stack<GameObject> _ninjaPoolStack;
		[SerializeField] private float hitsPerSecond;
		[SerializeField] private float hitRange;
		private float _hitInterval;
		private float _lastHit = 0;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_hitInterval = 1 / hitsPerSecond;
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

		public void OnTriggerStay(Collider other)
		{
			if (_lastHit + _hitInterval > Time.time) return;
			Hit(other.transform.position);
		}

		private void Hit(Vector3 targetPosition)
		{
			var hitDirection = targetPosition - transform.position;
			if (math.abs(hitDirection.x) > math.abs(hitDirection.y))
				hitDirection.y = 0;
			else
				hitDirection.x = 0;
			if (Physics.Raycast(transform.position, hitDirection, out var hitInfo, hitRange))
				hitInfo.collider.gameObject.GetComponent<IHittable>()?.TakeHit();
			_lastHit = Time.time;
		}
	
		public static void SetNinjaPoolStack(Stack<GameObject> poolStack)
		{
			_ninjaPoolStack = poolStack;
		}
	}
}