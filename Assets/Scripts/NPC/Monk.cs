using UnityEngine;

namespace NPC
{
    public class Monk : MonoBehaviour, IHittable
    {
        public void TakeHit()
        {
            print("Oh no! That is not a ninja!");
            Destroy(gameObject);
        }

        private void OnMouseDown()
        {

        }
    }
}
