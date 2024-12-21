using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose;

public static class DockerComposeUpSettingsExtensions
{
    [Pure]
    public static T SetDetach<T>(this T settings, bool detach)
        where T : DockerComposeUpSettings
    {
        settings = settings.NewInstance();
        settings.Detach = detach;
        return settings;
    }
}