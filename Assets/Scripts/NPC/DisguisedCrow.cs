using UnityEngine;

namespace NPC
{
	public class DisguisedCrow : Komuso
	{
		[SerializeField] private GameObject hiddenCrow;

		public override void TakeHit()
		{
			ExposeCrow();
		}

		protected override void OnMouseDown()
		{
			ExposeCrow();
		}
		
		private void ExposeCrow()
		{
			AudioManager.CrowFound();
			Animator.SetTrigger(SmokeBomb);
			var transform1 = transform;
			Instantiate(hiddenCrow, transform1.position, transform1.rotation);
		}
	}
}