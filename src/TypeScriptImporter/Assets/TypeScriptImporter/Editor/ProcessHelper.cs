using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace TypeScriptImporter.Editor
{
    internal static class ProcessHelper
    {
        public static void StartCompileProcess(string processFileName, string processArguments)
        {
            var psi = new ProcessStartInfo(processFileName, processArguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            var process = Process.Start(psi);

            var messageQueue = new ConcurrentQueue<string>();

            void LogStream(StreamReader reader, StringBuilder builder)
            {
                Task.Run(async () =>
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        builder.AppendLine(line);
                        Console.WriteLine(line);
                        messageQueue.Enqueue(line);
                    }
                });
            }

            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            LogStream(process.StandardOutput, standardOutput);
            LogStream(process.StandardError, standardError);

            var title = $"Compiling .ts files...";

            EditorUtility.DisplayProgressBar(title, title, 0f);
            try
            {
                while (!process.HasExited)
                {
                    string message = null;
                    while (messageQueue.TryDequeue(out var dequeued)) message = dequeued;

                    if (message != null) EditorUtility.DisplayProgressBar(title, message, 0f);

                    Thread.Sleep(100);
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            if (process.ExitCode != 0)
            {
                var errorStr = standardError.ToString();
                var outStr = standardOutput.ToString();
                throw new ProcessException($"Error: \n{errorStr}\n\nstdout:\n{outStr}", errorStr, outStr);
            }
        }
    }

    internal sealed class ProcessException : Exception
    {
        public ProcessException(string message, string stdError, string stdOut) : base(message)
        {
            StdError = stdError;
            StdOut = stdOut;
        }

        public string StdError { get; }
        public string StdOut { get; }
    }
}