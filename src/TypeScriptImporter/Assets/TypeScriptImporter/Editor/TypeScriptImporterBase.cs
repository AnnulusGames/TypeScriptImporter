using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    public abstract class TypeScriptImporterBase<TAsset> : ScriptedImporter
        where TAsset : ScriptableObject
    {   
        protected abstract string ArtifactFileExtension { get; }
        protected abstract TAsset CreateTypeScriptAsset();
        protected abstract void SetTypeScriptSource(TAsset asset, string source);
        protected abstract void SetCompiledSource(TAsset asset, string source);

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var fullAssetPath = assetPath.Replace("Assets", Application.dataPath);

            var asset = CreateTypeScriptAsset();
            var tsText = File.ReadAllText(assetPath);
            SetTypeScriptSource(asset, tsText);
            ctx.AddObjectToAsset("Main", asset);
            ctx.SetMainObject(asset);

            var artifactPath = fullAssetPath[0..^3] + ArtifactFileExtension;

            if (File.Exists(artifactPath))
            {
                var artifactText = File.ReadAllText(artifactPath);
                SetCompiledSource(asset, artifactText);
            }
            else
            {
                ctx.LogImportError($"{assetPath[0..^3] + ArtifactFileExtension} not found.");
            }
        }
    }
}