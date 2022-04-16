using UnityEngine;

namespace Player
{
	public class Crow : MonoBehaviour
	{
		private Transform _transform;
		private Camera _camera;

		private void Awake()
		{
			_transform = transform;
			_camera = Camera.main;
		}

		private void Update()
		{
			transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
			var localPos = _transform.localPosition;
			localPos.z += 2;
			_transform.localPosition = localPos;
		}
	}
}