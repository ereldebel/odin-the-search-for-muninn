using System.Collections;
using Unity.Mathematics;
using UnityEngine;
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
		private Transform _child;

		private int _npcLayer;


		private void Awake()
		{
			_child = transform.GetChild(0);
			hitAngle /= 2;
			_rigidbody = GetComponent<Rigidbody>();
			_npcLayer = LayerMask.GetMask("NPC");
		}

		private void Update()
		{
			var horizontalMovement = Input.GetAxis("Horizontal");
			var verticalMovement = Input.GetAxis("Vertical");
			var movementDir = new Vector3(horizontalMovement, 0f, verticalMovement);
			if (movementDir.magnitude >= 0.1f)
				Move(movementDir);
			if (Input.GetKeyDown(KeyCode.Space))
				Attack();
		}

		public void TakeHit()
		{
			SceneManager.LoadScene(0);
		}
		
		private void Move(Vector3 movementDir)
		{
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
				var raycastHits = Physics.RaycastAll(_child.position, direction, hitDistance, _npcLayer);
				Debug.DrawRay(_child.position, direction * hitDistance, Color.magenta, 0.5f);
				foreach (var hit in raycastHits)
					hit.collider.GetComponent<IHittable>()?.TakeHit();
				yield return new WaitForFixedUpdate();
			}

			_currentlyAttacking = false;
		}
	}
}