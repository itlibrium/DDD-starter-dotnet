using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace MyCompany.ECommerce.Nuke.DockerCompose;

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