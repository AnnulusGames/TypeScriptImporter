using UnityEditor;

namespace TypeScriptImporter.Editor
{
    public sealed class TscAssetPostProcessor : TypeScriptAssetPostProcessorBase
    {
        void OnPreprocessAsset()
        {
            OnPreprocessAssetCore("tsc", ".js", true);
        }

        static void OnPostprocessAllAssets(string[] importedAssetPaths, string[] deletedAssetPaths, string[] movedAssetPaths, string[] movedFromAssetPaths)
        {
            OnPostprocessAllAssetsCore(".js");
        }
    }
}