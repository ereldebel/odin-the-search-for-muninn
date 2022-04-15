using UnityEngine;

public class HitParent : MonoBehaviour, IHittable
{

	private IHittable _parentHittable;
	private void Awake()
	{
		_parentHittable = transform.parent.GetComponent<IHittable>();
	}

	public void TakeHit()
	{
		_parentHittable?.TakeHit();
	}
}