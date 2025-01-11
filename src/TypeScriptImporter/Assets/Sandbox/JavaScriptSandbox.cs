using System;
using Jint;
using TypeScriptImporter;
using UnityEngine;

public class JavaScriptSandbox : MonoBehaviour
{
    void Start()
    {
        var engine = new Engine()
            .SetValue("log", new Action<object>(Debug.Log));
        var asset = Resources.Load<TypeScriptAsset>("test_ts2js");

        engine.Execute(asset.JavaScriptSource);
    }
}