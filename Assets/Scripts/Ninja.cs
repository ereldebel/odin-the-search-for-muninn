using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour, IHittable
{
    private static Stack<GameObject> _ninjaPollStack; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeHit()
    {
        throw new System.NotImplementedException();
    }

    public static void SetNinjaPoolStack(Stack<GameObject> poolStack)
    {
        _ninjaPollStack = poolStack;
    }
}
