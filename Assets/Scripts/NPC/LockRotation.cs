using UnityEngine;

namespace NPC
{
    public class LockRotation : MonoBehaviour
    {
        private Quaternion _initialRotation;

        private void Awake()
        {
            _initialRotation = transform.rotation;
        }

        private void LateUpdate()
        {
            transform.rotation = _initialRotation;
        }
    }
}
