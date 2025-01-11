using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    public sealed class TypeScriptSettingsProviderRegister
    {
        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new SettingsProvider("Project/TypeScript Importer", SettingsScope.Project)
            {
                guiHandler = (searchContext) =>
                {
                    var serializedObject = new SerializedObject(TypeScriptSettings.instance);

                    EditorGUI.BeginChangeCheck();

                    EditorGUILayout.Space(5f);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("tsconfigAsset"), new GUIContent("tsconfig.json"));

                    var changed = EditorGUI.EndChangeCheck();
                    if (changed)
                    {
                        serializedObject.ApplyModifiedProperties();
                        TypeScriptSettings.instance.Save();
                    }
                },
                keywords = new HashSet<string>(new[] { "TypeScript" })
            };
        }
    }
}