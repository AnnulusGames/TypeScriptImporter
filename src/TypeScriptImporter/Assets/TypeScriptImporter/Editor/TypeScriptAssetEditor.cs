using UnityEditor;

namespace TypeScriptImporter.Editor
{
    [CustomEditor(typeof(TypeScriptAsset))]
    public sealed class TypeScriptAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var sourceProperty = serializedObject.FindProperty("source");
            var jsSourceProperty = serializedObject.FindProperty("javaScriptSource");

            EditorGUILayout.LabelField("TypeScript", EditorStyles.boldLabel);
            EditorGUILayout.TextArea(sourceProperty.stringValue);
            EditorGUILayout.LabelField("JavaScript", EditorStyles.boldLabel);
            EditorGUILayout.TextArea(jsSourceProperty.stringValue);
        }
    }
}