using UnityEngine;

namespace NPC
{
	public class DisguisedCrow : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			GetComponent<SpriteRenderer>().color = Color.blue;
		}
	}
}
