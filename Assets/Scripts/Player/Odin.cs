using System.Collections;
using UnityEngine;

namespace Player
{
	public class Odin : MonoBehaviour, IHittable
	{
		[SerializeField] private float speed = 6;
		[SerializeField] private float hitDistance = 10;
		[SerializeField] private float hitAngle = 100;
		[SerializeField] private float drawRayTime = 2;
		
		private Animator _animator;
		private Transform _transform;
		private Transform _child;
		private CharacterController _controller;

		private Vector3 _direction;
		private bool _currentlyAttacking;
		private int _npcLayer;
		private float _originalY;
		
		private static readonly int AttackTrigger = Animator.StringToHash("Attack");
		private static readonly int TakeHitTrigger = Animator.StringToHash("Take Hit");

		private void Awake()
		{
			_child = transform.GetChild(0);
			hitAngle /= 2;
			_animator = GetComponent<Animator>();
			_npcLayer = LayerMask.GetMask("NPC");
			_controller = GetComponent<CharacterController>();
			_transform = transform;
			_originalY = _transform.position.y;
		}

		private void Update()
		{
			var pos = _transform.position;
			pos.y = _originalY;
			_transform.position = pos;
			if (_currentlyAttacking) return;
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
			_animator.SetTrigger(TakeHitTrigger);
			GameManager.OdinHit();
		}
		
		private void Move(Vector3 movementDir)
		{
			_controller.Move(movementDir * speed * Time.deltaTime);
			_direction = Directions.GetProminentMoveDirection(movementDir);
			_animator.SetInteger(Directions.AnimatorDirection, Directions.VecToInt[_direction]);
		}
		
		private void Attack()
		{
			_animator.SetTrigger(AttackTrigger);
			StartCoroutine(AttackCoroutine(_direction));
		}

		private IEnumerator AttackCoroutine(Vector3 hitDirection)
		{
			_currentlyAttacking = true;
			var isSwingingRight = hitDirection == Vector3.left;
			for (var angle = -hitAngle; angle <= hitAngle; angle += 10)
			{
				var direction = Quaternion.AngleAxis(isSwingingRight? -angle : angle, Vector3.up) * hitDirection;
				var position = _child.position;
				var raycastHits = Physics.RaycastAll(position, direction, hitDistance, _npcLayer);
				Debug.DrawRay(position, direction * hitDistance, Color.magenta, drawRayTime);
				foreach (var hit in raycastHits)
					hit.collider.GetComponent<IHittable>()?.TakeHit();
				yield return new WaitForFixedUpdate();
			}

			_currentlyAttacking = false;
		}
	}
}