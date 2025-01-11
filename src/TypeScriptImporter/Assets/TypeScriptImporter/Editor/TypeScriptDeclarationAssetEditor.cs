using UnityEditor;

namespace TypeScriptImporter.Editor
{
    [CustomEditor(typeof(TypeScriptDeclarationAsset))]
    public sealed class TypeScriptDeclarationAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var sourceProperty = serializedObject.FindProperty("source");

            EditorGUILayout.LabelField("TypeScript", EditorStyles.boldLabel);
            EditorGUILayout.TextArea(sourceProperty.stringValue);
        }
    }
}