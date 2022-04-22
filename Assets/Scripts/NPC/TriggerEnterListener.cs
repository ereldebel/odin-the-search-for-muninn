using UnityEngine;

namespace NPC
{
	public class TriggerEnterListener : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			var parent = transform.parent;
			//parent.GetComponent<ITriggerUser>()?.EnteredTrigger(other);
			parent.GetComponentInChildren<ITriggerUser>()?.EnteredTrigger(other);
		}
	}
}