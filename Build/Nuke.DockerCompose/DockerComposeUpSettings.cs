using System;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose
{
    [Serializable]
    public class DockerComposeUpSettings : DockerComposeSettings
    {
        public bool Detach { get; internal set; }

        public DockerComposeUpSettings SetDetach(bool detach)
        {
            Detach = detach;
            return this;
        }

        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments = base.ConfigureProcessArguments(arguments);
            arguments.Add("up")
                .Add("--detach", Detach);
            return arguments;
        }
    }
}