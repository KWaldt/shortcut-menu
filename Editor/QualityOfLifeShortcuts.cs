using UnityEditor;
using UnityEngine;

namespace KristinaWaldt.ShortcutMenu
{
	public static class QualityOfLifeShortcuts
	{
		private const string MenuName = "Custom/";
		private const string ResetTransformName = MenuName + "Reset Transforms %&t";
		private const string RandomYRotationName = MenuName + "Set Random Y Rotation %&y";
		private const string CreateEmptyParentName = MenuName + "Create Empty Parent #p";
		private const string ParentFunctionsName = MenuName + "Parent To Last or Unparent &p";
		
		[MenuItem(ResetTransformName)]
		public static void ResetTransforms()
		{
			Undo.RegisterCompleteObjectUndo(Selection.transforms, "Undo Set Random Y Rotation");
			foreach (var transform in Selection.transforms)
			{
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				transform.localScale = Vector3.one;
			}
		}

		[MenuItem(ParentFunctionsName, true)]
		[MenuItem(ResetTransformName, true)]
		[MenuItem(RandomYRotationName, true)]
		private static bool ValidateHasTransformSelection()
		{
			return Selection.transforms.Length > 0;
		}
		
		[MenuItem(CreateEmptyParentName)]
		public static void CreateEmptyParent()
		{
			// Optional: Parent under same parent, but: what if the selection has different parents?
			
			Transform parent = new GameObject("Parent").transform;
			Vector3 position = GetCenterFromSelected();
			parent.position = position;
			Undo.RegisterCreatedObjectUndo(parent.gameObject, "Create Empty Parent");
			
			foreach (Transform transform in Selection.transforms)
			{
				Undo.SetTransformParent(transform, parent, "Create Empty Parent");
			}
		}

		[MenuItem(CreateEmptyParentName, true)]
		private static bool ValidateCreateEmptyParent()
		{
			return Selection.transforms.Length > 0;
		}

		[MenuItem(ParentFunctionsName)]
		public static void ParentFunctions()
		{
			// NOTE: Selection.objects stores the data in order selected, but we need to filter it.

			switch (Selection.gameObjects.Length)
			{
				case 0:
					return;
				case 1:
					UnparentSingle();
					break;
				default:
					ParentToLastSelected();
					break;
			}
		}
		
		private static void ParentToLastSelected()
		{
			Transform parent = null;
			for (var index = Selection.objects.Length - 1; index >= 0; index--)
			{
				var gameObject = Selection.objects[index] as GameObject;
				if (gameObject == null)
					continue;

				var transform = gameObject.transform;
				
				if (parent == null)
				{
					parent = gameObject.transform;
					continue;
				}

				Transform newParent = transform.parent != parent ? parent : transform.parent.parent; 
				Undo.SetTransformParent(gameObject.transform, newParent, "Undo Set Last As Parent");
			}
		}

		private static void UnparentSingle()
		{
			Transform transform = Selection.gameObjects[0].transform;

			if (transform.parent == null)
				return;

			var newParent = transform.parent.parent;
			Undo.SetTransformParent(transform, newParent, $"Undo Unparent {transform.gameObject.name}");
		}

		private static Vector3 GetCenterFromSelected()
		{
			Vector3 center = Vector3.zero;
			foreach (Transform transform in Selection.transforms)
			{
				center += transform.position;
			}
			center /= Selection.transforms.Length;
			return center;
		}
	}
}
