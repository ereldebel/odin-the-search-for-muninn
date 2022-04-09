using UnityEngine;

namespace NPC
{
	public class TriggerEnterListener : MonoBehaviour
	{
		[SerializeField] private DisguisedNinja ninja;
		private void OnTriggerEnter(Collider other)
		{
			ninja.OnTriggerEnter(other);
		}
	}
}