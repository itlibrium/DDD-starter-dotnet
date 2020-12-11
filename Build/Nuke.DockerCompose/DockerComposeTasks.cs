using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose
{
    public static class DockerComposeTasks
    {
        internal static string DockerPath => ToolPathResolver.GetPathExecutable("docker-compose");

        internal static void CustomLogger(OutputType type, string output)
        {
            switch (type)
            {
                case OutputType.Std:
                    Logger.Normal(output);
                    break;
                case OutputType.Err:
                {
                    if (output.StartsWith("WARNING!"))
                        Logger.Warn(output);
                    else
                        Logger.Normal(output);
                    //TODO: logging real errors
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static IReadOnlyCollection<Output> Up(Configure<DockerComposeUpSettings> configure) =>
            Up(configure(new DockerComposeUpSettings()));

        public static IReadOnlyCollection<Output> Up(DockerComposeUpSettings settings = null) =>
            StartProcess(settings ?? new DockerComposeUpSettings());

        public static IReadOnlyCollection<Output> Down(Configure<DockerComposeDownSettings> configure) =>
            Down(configure(new DockerComposeDownSettings()));

        public static IReadOnlyCollection<Output> Down(DockerComposeDownSettings settings = null) =>
            StartProcess(settings ?? new DockerComposeDownSettings());

        public static IReadOnlyCollection<Output> Logs(Configure<DockerComposeLogsSettings> configure) =>
            Logs(configure(new DockerComposeLogsSettings()));
        
        public static IReadOnlyCollection<Output> Logs(DockerComposeLogsSettings settings = null) =>
            StartProcess(settings ?? new DockerComposeLogsSettings());

        private static IReadOnlyCollection<Output> StartProcess([NotNull] ToolSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var process = ProcessTasks.StartProcess(settings);
            process.AssertWaitForExit();
            return process.Output;
        }
    }
}