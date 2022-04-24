using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Editor
{
	public class MenuItems
	{
		[MenuItem("Tools/Randomly place prefab &s")]
		private static void RandomlyPlacePrefab()
		{
			var go = PrefabUtility.InstantiatePrefab(Selection.activeObject as GameObject) as GameObject;
			if (go == null) return;
			var treeLayer = LayerMask.GetMask("Trees");
			var pos = go.transform.position;
			do
			{
				pos.x = Random.Range(-45, 45);
				pos.z = Random.Range(-45, 45);
			} while (Physics.OverlapSphere(pos, 4, treeLayer).Length != 0);

			go.transform.position = pos;
		}

		[MenuItem("Tools/Randomly place prefab in circle &#s")]
		private static void RandomlyPlacePrefabInCircle()
		{
			var go = PrefabUtility.InstantiatePrefab(Selection.activeObject as GameObject) as GameObject;
			if (go == null) return;
			var treeLayer = LayerMask.GetMask("Trees");
			var pos = go.transform.position;
			do
			{
				pos.x = Random.Range(-20, 20);
				pos.z = Random.Range(-20, 20);
			} while (Physics.OverlapSphere(pos, 1, treeLayer).Length != 0 && pos.z * pos.z + pos.x * pos.x < 13);

			go.transform.position = pos;
		}
	}
}