using System;
using Nuke.Common;

namespace MyCompany.ECommerce.Nuke;

public partial class Build
{
    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    public static string BuildConfiguration { get; private set; } = IsLocalBuild
        ? "Debug"
        : "Release";

    [Parameter]
    public static string ExecutingUser { get; private set; } = "1000";

    [Parameter]
    public static Environment Environment
    {
        get
        {
            if (!_environment.Equals(Environment.Undefined))
                return _environment;
            if (!AspNetCoreEnvironment.Equals(Environment.Undefined))
                return AspNetCoreEnvironment;
            if (!DotNetEnvironment.Equals(Environment.Undefined))
                return DotNetEnvironment;
            return Environment.Development;
        }
        private set
        {
            if (value.Equals(Environment.Undefined))
                throw new ArgumentException(
                    $"{nameof(Environment)} can not be set to {Environment.Undefined}");
            _environment = value;
        }
    }

    private static Environment _environment = Environment.Undefined;

    [Parameter]
    public static Environment DotNetEnvironment { get; private set; } = Environment.Undefined;

    [Parameter]
    public static Environment AspNetCoreEnvironment { get; private set; } = Environment.Undefined;
}