using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    [ScriptedImporter(1, ".d.ts")]
    public sealed class TypeScriptDeclarationAssetImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var text = File.ReadAllText(ctx.assetPath);
            var asset = ScriptableObject.CreateInstance<TypeScriptDeclarationAsset>();
            asset.source = text;
            ctx.AddObjectToAsset("Main", asset);
            ctx.SetMainObject(asset);
        }
    }
}