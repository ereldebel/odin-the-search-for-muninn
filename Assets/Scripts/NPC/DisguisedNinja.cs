using Managers;
using UnityEngine;

namespace NPC
{
    public class DisguisedNinja : Komuso, ITriggerUser
    {
        public override void TakeHit()
        {
            GameManager.NinjaHit();
            Destroy(gameObject);
        }

        protected override void OnMouseDown()
        {
            TransformIntoNinja();
        }

        public void EnteredTrigger(Collider other)
        {
            TransformIntoNinja();
        }
    
        private void TransformIntoNinja()
        {
            Collider.enabled = false;
            Animator.SetTrigger(SmokeBomb);
            GameManager.NinjaPool.SpawnNinja(transform.position);
            Destroy(this);
        }
    }
}
