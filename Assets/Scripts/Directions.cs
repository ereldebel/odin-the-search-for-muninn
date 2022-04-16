using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class Directions
{
	public static readonly int AnimatorDirection = Animator.StringToHash("Direction");

	public const int Front = 0, Left = 1, Back = 2, Right = 3;

	public static Dictionary<Vector3, int> VecToInt { get; } = new Dictionary<Vector3, int>
	{
		{Vector3.forward, Back},
		{Vector3.left, Left},
		{Vector3.back, Front},
		{Vector3.right, Right}
	};

	public static Vector3 GetProminentMoveDirection(Vector3 movementDir)
	{
		return math.abs(movementDir.x) > math.abs(movementDir.z)
			? new Vector3(movementDir.x, 0, 0).normalized
			: new Vector3(0, 0, movementDir.z).normalized;
	}

	public static int GetProminentRotationDirection(Vector3 rotation)
	{
		return (((int) rotation.y + 45) / 90 + 2) % 4;
	}
}