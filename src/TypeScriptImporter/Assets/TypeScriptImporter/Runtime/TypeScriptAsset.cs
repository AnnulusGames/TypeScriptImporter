using UnityEngine;

namespace TypeScriptImporter
{
    public sealed class TypeScriptAsset : ScriptableObject
    {
        [SerializeField] internal string source;
        [SerializeField] internal string javaScriptSource;

        public string Source => source;
        public string JavaScriptSource => javaScriptSource;
    }
}