using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
	public class Ninja : MonoBehaviour, IHittable, ITriggerUser
	{
		private NavMeshAgent _navMeshAgent;
		private Animator _animator;
		private static Stack<GameObject> _ninjaPoolStack;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			_navMeshAgent.SetDestination(GameManager.Odin.position);
			var movementDir = Directions.GetProminentMoveDirection(_navMeshAgent.velocity);
			_animator.SetInteger(Directions.AnimatorDirection, Directions.VecToInt[movementDir]);
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