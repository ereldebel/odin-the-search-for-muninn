using NPC;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField] private Transform odin;
	
	private static GameManager _shared;

	public static NinjaPool NinjaPool { get; private set; }
	public static Transform Odin { get; private set; }

	private void Awake()
	{
		_shared = this;
		NinjaPool = GetComponent<NinjaPool>();
		Odin = odin;
	}

	private void Update()
	{
		
	}
}
