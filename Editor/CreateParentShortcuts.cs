using UnityEditor;
using UnityEngine;

namespace KristinaWaldt.ShortcutMenu
{
    public static class CreateParentShortcuts
    {
        private const string CreateEmptyParentName = Settings.MenuName + "Create Empty Parent #p";
        
        [MenuItem(CreateEmptyParentName)]
        public static void CreateEmptyParent()
        {
            // Optional: Parent under same parent, but: what if the selection has different parents?
			
            Transform parent = new GameObject("Parent").transform;
            parent.position = GetCenterFromSelected();
            Undo.RegisterCreatedObjectUndo(parent.gameObject, "Create Empty Parent");
			
            foreach (Transform transform in Selection.transforms)
            {
                Undo.SetTransformParent(transform, parent, "Create Empty Parent");
            }
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
        
        [MenuItem(CreateEmptyParentName, true)]
        private static bool ValidateHasTransformSelection() => Settings.ValidateHasTransformSelection();
    }
}