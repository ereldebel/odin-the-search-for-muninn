using UnityEngine;

namespace NPC
{
	public class Komuso : MonoBehaviour, IHittable
	{
		protected Animator Animator;
		private Transform _parent;
		private static readonly int RaiseBasket = Animator.StringToHash("Raise Basket");
		protected static readonly int SmokeBomb = Animator.StringToHash("Smoke Bomb");

		private void Awake()
		{
			_parent = transform.parent;
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
		}

		public virtual void TakeHit()
		{
			AudioManager.KomusoDeath();
			GameManager.KomusoHit();
			Destroy(_parent.gameObject);
		}
	}
}