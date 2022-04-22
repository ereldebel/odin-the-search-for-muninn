using System;
using UnityEngine;

namespace NPC
{
	public class DisguisedCrow : MonoBehaviour, IHittable
	{
		//private Animator _animator;
		//private Transform _parent;

		[SerializeField] private GameObject hiddenCrow;

		private void Awake()
		{
			//_parent = transform.parent;
			//_animator = _parent.GetComponent<Animator>();
		}

		public void TakeHit()
		{
			Instantiate(hiddenCrow, gameObject.transform);
			Destroy(gameObject);
		}

		private void Update()
		{
			//_animator.SetInteger(Directions.AnimatorDirection,
				//Directions.GetProminentRotationDirection(_parent.rotation.eulerAngles));
		}
	}


		//private void OnCollisionEnter(Collision collision)
		//{
		//	if (collision.gameObject.CompareTag("Odin"))
		//		GetComponent<SpriteRenderer>().color = Color.blue;
		//}
	}

