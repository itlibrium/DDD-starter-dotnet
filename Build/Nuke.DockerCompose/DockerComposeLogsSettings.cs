using System;
using Nuke.Common.Tooling;

namespace MyCompany.ECommerce.Nuke.DockerCompose;

[Serializable]
public class DockerComposeLogsSettings : DockerComposeSettings
{
    public bool Follow { get; internal set; }

    public DockerComposeLogsSettings SetFollow(bool follow)
    {
        Follow = follow;
        return this;
    }

    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments = base.ConfigureProcessArguments(arguments);
        arguments.Add("logs")
            .Add("--follow", Follow);
        return arguments;
    }
}