using System;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose
{
    [Serializable]
    public class DockerComposeDownSettings : DockerComposeSettings
    {
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments = base.ConfigureArguments(arguments);
            arguments.Add("down");
            return arguments;
        }
    }
}