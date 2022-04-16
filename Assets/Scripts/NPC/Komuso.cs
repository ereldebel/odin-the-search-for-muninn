using UnityEngine;

namespace NPC
{
	public class Komuso : MonoBehaviour, IHittable
	{
		private Animator _animator;
		private Transform _parent;

		private void Awake()
		{
			_parent = transform.parent;
			_animator = _parent.GetComponent<Animator>();
		}

		public void TakeHit()
		{
			print("Oh no! That is not a ninja!");
			Destroy(_parent.gameObject);
		}

		private void Update()
		{
			_animator.SetInteger(Directions.AnimatorDirection,
				Directions.GetProminentRotationDirection(_parent.rotation.eulerAngles));
		}
	}
}