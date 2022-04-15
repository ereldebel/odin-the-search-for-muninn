using UnityEngine;

namespace NPC
{
	public class DisguisedCrow : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Odin"))
				GetComponent<SpriteRenderer>().color = Color.blue;
		}
	}
}
