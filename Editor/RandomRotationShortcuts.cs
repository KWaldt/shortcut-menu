using UnityEditor;
using UnityEngine;

namespace KristinaWaldt.ShortcutMenu
{
    public static class RandomRotationShortcuts
    {
        private const string RandomYRotationName = Settings.MenuName + "Set Random Y Rotation %&y";

        [MenuItem(RandomYRotationName)]
        public static void RandomYRotation()
        {
            Undo.RegisterCompleteObjectUndo(Selection.transforms, "Undo Set Random Y Rotation");
            foreach (var transform in Selection.transforms)
            {
                Vector3 tempRotation = transform.localEulerAngles;
                tempRotation.y = Random.Range(0, 359);
                transform.localRotation = Quaternion.Euler(tempRotation);
            }
        }
        
        [MenuItem(RandomYRotationName, true)]
        private static bool ValidateHasTransformSelection() => Settings.ValidateHasTransformSelection();
    }
}