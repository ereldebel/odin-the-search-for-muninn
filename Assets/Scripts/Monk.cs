using UnityEngine;

public class Monk : MonoBehaviour, IHittable, IClickable
{
    [SerializeField] private bool isNinja;
    [SerializeField] private NinjaPool ninjaPool;

    public void TakeHit()
    {
        if (isNinja)
            Destroy(gameObject);
        else
            print("Oh no! That is not a ninja!");
    }

    public void Click()
    {
        if (isNinja)
            ninjaPool.SpawnNinja(transform.position);
    }
}
