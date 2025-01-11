using Lua;
using TypeScriptImporter;
using UnityEngine;

public class LuaSandbox : MonoBehaviour
{
    async void Start()
    {
        var state = LuaState.Create();
        state.Environment["print"] = new LuaFunction("print", (context, buffer, ct) =>
        {
            Debug.Log(context.GetArgument(0));
            return new(0);
        });

        var asset = Resources.Load<TypeScriptToLuaAsset>("test_ts2lua");
        await state.DoStringAsync(asset.LuaSource, cancellationToken: destroyCancellationToken);
    }
}
