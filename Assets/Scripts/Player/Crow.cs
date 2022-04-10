using UnityEngine;

namespace Player
{
    public class Crow : MonoBehaviour
    {
        private void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }
}
