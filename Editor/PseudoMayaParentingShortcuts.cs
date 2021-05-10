using UnityEditor;
using UnityEngine;

namespace KristinaWaldt.ShortcutMenu
{
    public static class PseudoMayaParentingShortcuts
    {
        private const string ParentFunctionsName = Settings.MenuName + "Parent To Last or Unparent &p";

        [MenuItem(ParentFunctionsName)]
        public static void ParentFunctions()
        {
            // NOTE: We use Selection.objects because it stores the data in the order selected.

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

        [MenuItem(ParentFunctionsName, true)]
        private static bool ValidateHasTransformSelection() => Settings.ValidateHasTransformSelection();
    }
}