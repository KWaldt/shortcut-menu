using UnityEditor;

namespace KristinaWaldt.ShortcutMenu
{
    public static class LightingShortcuts
    {
        private const string BakeLightingName = Settings.MenuName + "Bake Lighting #b";

        [MenuItem(BakeLightingName)]
        public static void BakeLighting()
        {
            Lightmapping.BakeAsync();
        }
    }
}