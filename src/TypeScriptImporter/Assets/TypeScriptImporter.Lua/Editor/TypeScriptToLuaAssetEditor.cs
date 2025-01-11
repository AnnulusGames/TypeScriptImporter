using UnityEditor;

namespace TypeScriptImporter.Editor
{
    [CustomEditor(typeof(TypeScriptToLuaAsset))]
    public sealed class TypeScriptToLuaAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var sourceProperty = serializedObject.FindProperty("source");
            var luaSourceProperty = serializedObject.FindProperty("luaSource");

            EditorGUILayout.LabelField("TypeScript", EditorStyles.boldLabel);
            EditorGUILayout.TextArea(sourceProperty.stringValue);
            EditorGUILayout.LabelField("Lua", EditorStyles.boldLabel);
            EditorGUILayout.TextArea(luaSourceProperty.stringValue);
        }
    }
}