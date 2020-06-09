using System;
using System.Collections.Generic;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose
{
    [Serializable]
    public class DockerComposeSettings : ToolSettings
    {
        public override string ToolPath => DockerComposeTasks.DockerPath;
        public override Action<OutputType, string> CustomLogger => DockerComposeTasks.CustomLogger;

        internal List<string> FileInternal;
        public IReadOnlyCollection<string> File => FileInternal.AsReadOnly();

        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments.Add("--file {value}", File);
            return base.ConfigureArguments(arguments);
        }
    }
}