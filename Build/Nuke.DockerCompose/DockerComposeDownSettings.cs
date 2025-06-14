using System;
using Nuke.Common.Tooling;

namespace MyCompany.ECommerce.Nuke.DockerCompose;

[Serializable]
public class DockerComposeDownSettings : DockerComposeSettings
{
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments = base.ConfigureProcessArguments(arguments);
        arguments.Add("down");
        return arguments;
    }
}