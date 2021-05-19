using UnityEditor;
using UnityEngine;

namespace KristinaWaldt.ShortcutMenu
{
    public static class ResetShortcuts
    {
        private const string ResetTransformName = Settings.MenuName + "Reset Transforms %&t";

        [MenuItem(ResetTransformName)]
        public static void ResetTransforms()
        {
            Undo.RegisterCompleteObjectUndo(Selection.transforms, "Set Random Y Rotation");
            foreach (var transform in Selection.transforms)
            {
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                transform.localScale = Vector3.one;
            }
        }
        
        [MenuItem(ResetTransformName, true)]
        private static bool ValidateHasTransformSelection() => Settings.ValidateHasTransformSelection();
    }
}