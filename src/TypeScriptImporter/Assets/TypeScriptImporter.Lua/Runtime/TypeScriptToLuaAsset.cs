using UnityEngine;

namespace TypeScriptImporter
{
    public sealed class TypeScriptToLuaAsset : ScriptableObject
    {
        [SerializeField] internal string source;
        [SerializeField] internal string luaSource;

        public string Source => source;
        public string LuaSource => luaSource;
    }
}