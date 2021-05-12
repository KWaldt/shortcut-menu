using System;
using UnityEditor;
using UnityEngine;

namespace KristinaWaldt.ShortcutMenu
{
	public class ShortcutWindow : EditorWindow
	{
		private const float SpacePixels = 10;
		
		// Priority 1 places it at the top and adds a divider.
		[MenuItem(Settings.MenuName + "Shortcuts Window", priority = 1)]
		public static void Init()
		{
			var window = (ShortcutWindow) GetWindow(typeof(ShortcutWindow));
			window.titleContent = new GUIContent("Shortcuts");
			window.Show();
		}

		private void OnGUI()
		{
			DrawTitle("Reset");
			DrawButton(ResetShortcuts.ResetTransforms);
			AddSpace();

			DrawTitle("Random");
			DrawButton(RandomRotationShortcuts.RandomYRotation);
			AddSpace();

			DrawTitle("Lighting");
			DrawButton(LightingShortcuts.BakeLighting);
			DrawButton(LightingShortcuts.StopBakeLighting);
			AddSpace();
			
			DrawTitle("Parenting");
			DrawButton(CreateParentShortcuts.CreateEmptyParent);
			DrawButton(PseudoMayaParentingShortcuts.PseudoMayaParenting);
		}

		private static void DrawButton(Action action)
		{
			if (GUILayout.Button(ObjectNames.NicifyVariableName(action.Method.Name)))
			{
				action.Invoke();
			}
		}

		private static void DrawTitle(string title)
		{
			// We're using the flexible space to centre our label.
			
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			
			GUILayout.Label($"••♦ {title} ♦••", EditorStyles.boldLabel);
			
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}

		private static void AddSpace()
		{
			GUILayout.Space(SpacePixels);
		}
	}
}
