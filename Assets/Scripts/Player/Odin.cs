using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Player
{
	public class Odin : MonoBehaviour, IHittable
	{
		[SerializeField] private CharacterController controller;
		[SerializeField] private float speed = 6;
		[SerializeField] private float hitDistance = 10;
		[SerializeField] private float hitAngle = 100;
		
		private Vector3 _direction;
		private bool _currentlyAttacking;
		private Rigidbody _rigidbody;

		private int _npcLayer;


		private void Awake()
		{
			hitAngle /= 2;
			_rigidbody = GetComponent<Rigidbody>();
			_npcLayer = LayerMask.NameToLayer("NPC");
		}

		private void Update()
		{
			var horizontalMovement = Input.GetAxisRaw("Horizontal");
			var verticalMovement = Input.GetAxisRaw("Vertical");
			var movementDir = new Vector3(horizontalMovement, 0f, verticalMovement);
			if (movementDir.magnitude >= 0.1f)
				Move(movementDir);
			if (Input.GetKeyDown(KeyCode.Space))
				Attack();
		}

		public void TakeHit()
		{
			throw new System.NotImplementedException();
		}
		
		private void Move(Vector3 movementDir)
		{
			// controller.Move(movementDir * speed * Time.deltaTime);
			_rigidbody.position += movementDir * speed * Time.deltaTime;
			_direction = math.abs(movementDir.x) > math.abs(movementDir.z)
				? new Vector3(movementDir.x, 0, 0).normalized
				: new Vector3(0, 0, movementDir.z).normalized;
		}
		
		private void Attack()
		{
			if (_currentlyAttacking) return;
			StartCoroutine(AttackCoroutine());
		}

		private IEnumerator AttackCoroutine() // direction?
		{
			_currentlyAttacking = true;
			for (var angle = -hitAngle; angle <= hitAngle; angle += 10)
			{
				var direction = Quaternion.AngleAxis(angle, Vector3.up) * _direction;
				var raycastHits = Physics.RaycastAll(transform.position, direction, hitDistance, _npcLayer);
				Debug.DrawRay(transform.position, direction * hitDistance, Color.magenta, 0.5f);
				foreach (var hit in raycastHits)
					hit.collider.GetComponent<IHittable>()?.TakeHit();
				yield return new WaitForFixedUpdate();
			}

			_currentlyAttacking = false;
		}
	}
}