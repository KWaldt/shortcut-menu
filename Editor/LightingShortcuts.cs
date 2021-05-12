using UnityEditor;

namespace KristinaWaldt.ShortcutMenu
{
    public static class LightingShortcuts
    {
        private const string BakeLightingName = Settings.MenuName + "Bake Lighting #b";
        private const string StopBakeLightingName = Settings.MenuName + "Stop Bake Lighting";

        [MenuItem(BakeLightingName)]
        public static void BakeLighting()
        {
            Lightmapping.BakeAsync();
        }
        
        [MenuItem(StopBakeLightingName)]
        public static void StopBakeLighting()
        {
            Lightmapping.ForceStop();
        }
    }
}