using UnityEngine;

namespace NPC
{
	public class TriggerEnterListener : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			transform.parent.GetComponentInChildren<ITriggerUser>()?.EnteredTrigger(other);
		}
	}
}