using UnityEditor;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    [FilePath("ProjectSettings/TypeScriptSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public sealed class TypeScriptSettings : ScriptableSingleton<TypeScriptSettings>
    {
        [SerializeField] TextAsset tsconfigAsset;

        public TextAsset TSConfigAsset => tsconfigAsset;

        public void Save()
        {
            Save(true);
        }
    }
}