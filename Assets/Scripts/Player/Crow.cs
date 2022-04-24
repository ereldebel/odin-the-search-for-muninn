using UnityEngine;

namespace Player
{
	public class Crow : MonoBehaviour
	{
		[SerializeField] private float sensitivityBuffer = 0.05f;
		
		private Transform _transform;
		private SpriteRenderer _spriteRenderer;
		private Animator _animator;
		private Camera _camera;
		
		private Vector3 _lastPos;
		private bool _isFacingLeft = false;
		private static readonly int Attack = Animator.StringToHash("Attack");

		private void Awake()
		{
			_transform = transform;
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_animator = GetComponent<Animator>();
			_camera = Camera.main;
			_lastPos = _transform.localPosition;
		}

		private void Update()
		{
			transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
			var localPos = _transform.localPosition;
			localPos.z += 2;
			_transform.localPosition = localPos;
			var xDiff = (localPos - _lastPos).x;
			if (xDiff > sensitivityBuffer && _isFacingLeft)
				_spriteRenderer.flipX = _isFacingLeft = false;
			else if (xDiff < -sensitivityBuffer && !_isFacingLeft)
				_spriteRenderer.flipX = _isFacingLeft = true;
			_lastPos = localPos;
			
			if(Input.GetMouseButtonDown(0))
				_animator.SetTrigger(Attack);
		}
	}
}