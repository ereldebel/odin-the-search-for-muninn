using NPC;
using UnityEngine;

namespace Player
{
    public class Odin : MonoBehaviour, IHittable
    {
        [SerializeField] CharacterController controller;
        [SerializeField] float speed = 6f;

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(horizontal, 0f, vertical);
        
            if (dir.magnitude >= 0.1f)
            {
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                // transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
                controller.Move(dir * speed * Time.deltaTime);
            }
        }

        public void TakeHit()
        {
            throw new System.NotImplementedException();
        }
    }
}
