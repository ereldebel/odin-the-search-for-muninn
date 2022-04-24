using UnityEngine;

namespace NPC
{
    public class DisguisedNinja : Komuso, ITriggerUser
    {
        public override void TakeHit()
        {
            Destroy(transform.parent.gameObject);
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
            Animator.SetTrigger(SmokeBomb);
            GameManager.NinjaPool.SpawnNinja(transform.position);
            Destroy(this);
        }
    }
}
