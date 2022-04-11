using UnityEngine;

namespace NPC
{
	internal interface ITriggerUser
	{
		void EnteredTrigger(Collider other);
	}
}