using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
    public class Monk : MonoBehaviour, IHittable
    {
        public void TakeHit()
        {
            print("Oh no! That is not a ninja!");
            Destroy(transform.parent.gameObject);
        }

        private void OnMouseDown()
        {
            
        }
    }
}
