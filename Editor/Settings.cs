using UnityEditor;

namespace KristinaWaldt.ShortcutMenu
{
	public static class Settings
	{
		public const string MenuName = "Custom/";

		public static bool ValidateHasTransformSelection()
		{
			return Selection.transforms.Length > 0;
		}
	}
}
