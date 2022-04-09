using UnityEngine;

namespace NPC
{
	public class TriggerStayListener : MonoBehaviour
	{
		[SerializeField] private Ninja ninja;
		private void OnTriggerStay(Collider other)
		{
			ninja.OnTriggerStay(other);
		}
	}
}