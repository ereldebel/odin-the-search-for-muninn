using System;
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
		private static readonly int Attack = Animator.StringToHash("Attack");
		private IHittable _othersHittable;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_animator = GetComponent<Animator>();
		}

		private void OnEnable()
		{
			AudioManager.NinjaSpawn();
		}

		private void Update()
		{
			_navMeshAgent.SetDestination(GameManager.Odin.position);
			var movementDir = Directions.GetProminentMoveDirection(_navMeshAgent.velocity);
			_animator.SetInteger(Directions.AnimatorDirection, Directions.VecToInt[movementDir]);
		}

		public void TakeHit()
		{
			AudioManager.NinjaDeath();
			GameManager.NinjaHit();
			gameObject.SetActive(false);
		}

		private void OnDisable()
		{
			_ninjaPoolStack.Push(gameObject);
		}

		public void EnteredTrigger(Collider other)
		{
			AudioManager.NinjaAttack();
			_othersHittable = other.GetComponent<IHittable>();
			_animator.SetTrigger(Attack);
		}

		public static void SetNinjaPoolStack(Stack<GameObject> poolStack)
		{
			_ninjaPoolStack = poolStack;
		}

		public void AnimatorHit()
		{
			_othersHittable?.TakeHit();
		}

		public void AnimatorDisable()
		{
			gameObject.SetActive(false);
		}
	}
}