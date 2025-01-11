using System.Text;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    [ScriptedImporter(1, new string[0], new string[] { ".ts" })]
    public class TS2LuaImporter : TypeScriptImporterBase<TypeScriptToLuaAsset>
    {
        protected override string ArtifactFileExtension => ".lua";

        protected override TypeScriptToLuaAsset CreateTypeScriptAsset()
        {
            return ScriptableObject.CreateInstance<TypeScriptToLuaAsset>();
        }

        protected override void SetCompiledSource(TypeScriptToLuaAsset asset, string source)
        {
            asset.luaSource = source;
        }

        protected override void SetTypeScriptSource(TypeScriptToLuaAsset asset, string source)
        {
            asset.source = source;
        }
    }
}