namespace TypeScriptImporter.Editor
{
    public sealed class TstlAssetPostProcessor : TypeScriptAssetPostProcessorBase
    {
        void OnPreprocessAsset()
        {
            OnPreprocessAssetCore("tstl", ".lua", false);
        }

        static void OnPostprocessAllAssets(string[] importedAssetPaths, string[] deletedAssetPaths, string[] movedAssetPaths, string[] movedFromAssetPaths)
        {
            OnPostprocessAllAssetsCore(".lua");
        }
    }
}