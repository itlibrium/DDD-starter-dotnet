using System;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose
{
    [Serializable]
    public class DockerComposeLogsSettings : DockerComposeSettings
    {
        public bool Follow { get; internal set; }

        public DockerComposeLogsSettings SetFollow(bool follow)
        {
            Follow = follow;
            return this;
        }

        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments = base.ConfigureArguments(arguments);
            arguments.Add("logs")
                .Add("--follow", Follow);
            return arguments;
        }
    }
}