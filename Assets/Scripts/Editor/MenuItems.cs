using UnityEditor;
using UnityEngine;

namespace Editor
{
	public class MenuItems
	{
		[MenuItem("Tools/Randomly place prefab &s")]
		private static void NewMenuOption()
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
	}
}