using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.DockerCompose;

public static class DockerComposeSettingsExtensions
{
    [Pure]
    public static T SetFile<T>(this T settings, params string[] files) where T : DockerComposeSettings => 
        SetFile(settings, (IEnumerable<string>) files);
        
    [Pure]
    public static T SetFile<T>(this T settings, IEnumerable<string> files)
        where T : DockerComposeSettings
    {
        settings = settings.NewInstance();
        settings.FileInternal = files.ToList();
        return settings;
    }
}