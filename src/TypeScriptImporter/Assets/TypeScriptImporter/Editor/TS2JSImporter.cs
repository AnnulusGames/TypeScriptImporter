using UnityEditor.AssetImporters;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    [ScriptedImporter(1, ".ts")]
    public class TS2JSImporter : TypeScriptImporterBase<TypeScriptAsset>
    {
        protected override string ArtifactFileExtension => ".js";

        protected override TypeScriptAsset CreateTypeScriptAsset()
        {
            return ScriptableObject.CreateInstance<TypeScriptAsset>();
        }

        protected override void SetCompiledSource(TypeScriptAsset asset, string source)
        {
            asset.javaScriptSource = source;
        }

        protected override void SetTypeScriptSource(TypeScriptAsset asset, string source)
        {
            asset.source = source;
        }
    }
}