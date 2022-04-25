using Managers;
using UnityEngine;

namespace NPC
{
	public class Komuso : MonoBehaviour, IHittable
	{
		protected Animator Animator;
		protected Collider Collider;
		private Transform _parent;
		private static readonly int RaiseBasket = Animator.StringToHash("Raise Basket");
		protected static readonly int SmokeBomb = Animator.StringToHash("Smoke Bomb");
		private static readonly int Hit = Animator.StringToHash("Take Hit");

		private void Awake()
		{
			_parent = transform.parent;
			Collider = GetComponent<Collider>();
			Animator = _parent.GetComponent<Animator>();
		}
		private void Update()
		{
			Animator.SetInteger(Directions.AnimatorDirection,
				Directions.GetProminentRotationDirection(_parent.rotation.eulerAngles));
		}
		
		protected virtual void OnMouseDown()
		{
			Animator.SetTrigger(RaiseBasket);
			AudioManager.RaiseBasket();
		}

		public virtual void TakeHit()
		{
			Collider.enabled = false;
			Animator.SetTrigger(Hit);
			AudioManager.KomusoDeath();
			GameManager.KomusoHit();
		}

		public void AnimatorDestroy()
		{
			Destroy(_parent.gameObject);
			
		}
	}
}