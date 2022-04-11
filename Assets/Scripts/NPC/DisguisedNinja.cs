using UnityEngine;

namespace NPC
{
    public class DisguisedNinja : MonoBehaviour, IHittable, ITriggerUser
    {
        public void TakeHit()
        {
            print("hurray!");
            Destroy(gameObject);
        }

        private void OnMouseDown()
        {
            TransformIntoNinja();
        }

        public void EnteredTrigger(Collider other)
        {
            TransformIntoNinja();
        }
    
        private void TransformIntoNinja()
        {
            GameManager.NinjaPool.SpawnNinja(transform.position);
            Destroy(gameObject);
        }
    }
}
