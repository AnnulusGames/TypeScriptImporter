using UnityEngine;

namespace TypeScriptImporter.Editor
{
    internal static class DebugEx
    {
        public static void LogError(object message, StackTraceLogType stackTraceType = StackTraceLogType.ScriptOnly)
        {
            LogInternal(LogType.Error, message, stackTraceType);
        }

        public static void LogWarning(object message, StackTraceLogType stackTraceType = StackTraceLogType.ScriptOnly)
        {
            LogInternal(LogType.Warning, message, stackTraceType);
        }

        public static void Log(object message, StackTraceLogType stackTraceType = StackTraceLogType.ScriptOnly)
        {
            LogInternal(LogType.Log, message, stackTraceType);
        }

        static void LogInternal(LogType logType, object message, StackTraceLogType stackTraceType)
        {
            var currentStackTraceType = Application.GetStackTraceLogType(logType);
            if (currentStackTraceType != stackTraceType)
            {
                Application.SetStackTraceLogType(logType, stackTraceType);
            }

            switch (logType)
            {
                case LogType.Error:
                    Debug.LogError(message);
                    break;

                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;

                case LogType.Log:
                    Debug.Log(message);
                    break;
            }

            if (currentStackTraceType != stackTraceType)
            {
                Application.SetStackTraceLogType(logType, currentStackTraceType);
            }
        }
    }
}