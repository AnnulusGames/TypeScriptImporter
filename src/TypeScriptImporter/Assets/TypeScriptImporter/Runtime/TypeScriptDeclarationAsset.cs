using UnityEngine;

namespace TypeScriptImporter
{
    public sealed class TypeScriptDeclarationAsset : ScriptableObject
    {
        [SerializeField] internal string source;

        public string Source => source;
    }
}