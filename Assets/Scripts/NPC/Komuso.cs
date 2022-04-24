using UnityEngine;

namespace NPC
{
	public class Komuso : MonoBehaviour, IHittable
	{
		protected Animator _animator;
		private Transform _parent;
		private static readonly int RaiseBasket = Animator.StringToHash("Raise Basket");
		protected static readonly int SmokeBomb = Animator.StringToHash("Smoke Bomb");

		private void Awake()
		{
			_parent = transform.parent;
			_animator = _parent.GetComponent<Animator>();
		}
		private void Update()
		{
			_animator.SetInteger(Directions.AnimatorDirection,
				Directions.GetProminentRotationDirection(_parent.rotation.eulerAngles));
		}
		
		protected virtual void OnMouseDown()
		{
			_animator.SetTrigger(RaiseBasket);
		}

		public virtual void TakeHit()
		{
			GameManager.KomusoHit();
			Destroy(_parent.gameObject);
		}
	}
}