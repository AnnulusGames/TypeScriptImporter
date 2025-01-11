using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    public abstract class TypeScriptAssetPostProcessorBase : AssetPostprocessor
    {
        protected void OnPreprocessAssetCore(string commandName, string artifactFileExtension, bool logTsError)
        {
            if (Path.GetExtension(assetPath) != ".ts") return;
            if (File.Exists(assetPath[0..^3] + artifactFileExtension)) return;

            var tempConfigPath = Application.dataPath + "/__tsconfig.temp.json";
            var args = new StringBuilder();

            if (TypeScriptSettings.instance.TSConfigAsset == null)
            {
                var defaultConfig = 
@$"{{ 
    ""include"": [ ""./**/*.ts"", ""./**/*.d.ts"" ],
    ""tstl"": {{
        ""luaLibImport"": ""inline""
    }}
}}";    
                File.WriteAllText(tempConfigPath, defaultConfig);
                args.Append($" -p {tempConfigPath} ");
            }
            else
            {
                var configPath = AssetDatabase.GetAssetPath(TypeScriptSettings.instance.TSConfigAsset).Replace("Assets", Application.dataPath);
                args.Append($" -p {configPath} ");
            }

            try
            {
                ProcessHelper.StartCompileProcess(
#if UNITY_EDITOR_WIN
                    "npx", $"{commandName} {args}" 
#else
                    "/bin/bash", $"-cl 'npx {commandName} {args}'"
#endif
                );
            }
            catch (ProcessException processEx)
            {
                if (processEx.StdOut.Contains("error TS"))
                {
                    if (logTsError) DebugEx.LogError(processEx.StdOut, StackTraceLogType.None);
                }
                else
                {
                    DebugEx.LogError(processEx.Message);
                }
            }
            catch (Exception ex)
            {
                DebugEx.LogError(ex.Message);
            }

            if (File.Exists(tempConfigPath))
            {
                File.Delete(tempConfigPath);
            }
        }

        protected static void OnPostprocessAllAssetsCore(string artifactFileExtension)
        {
            foreach (var asset in AssetDatabase.GetAllAssetPaths())
            {
                if (Path.GetExtension(asset) == ".ts")
                {
                    var artifactPath = asset[0..^3] + artifactFileExtension;

                    if (File.Exists(artifactPath))
                    {
                        File.Delete(artifactPath);
                    }
                }
            }
        }
    }
}