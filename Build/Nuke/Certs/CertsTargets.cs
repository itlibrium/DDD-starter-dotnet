using System;
using Nuke.Common;
using Nuke.Common.IO;
using static Nuke.Common.IO.FileSystemTasks;
using static MyCompany.Crm.Nuke.Environment;
using static MyCompany.Crm.Nuke.Paths;

namespace MyCompany.Crm.Nuke.Certs
{
    public static class CertsTargets
    {
        public static readonly AbsolutePath CertsDirectory = ArtifactsDirectory / "Certs";
        private static readonly AbsolutePath DevCertsDirectory = NukeDirectory / "Certs" / "DevCerts";

        public static Target PrepareCertificates => _ => _
            .Executes(() =>
            {
                if (EnvironmentIs(Development))
                {
                    if (!DirectoryExists(CertsDirectory))
                        CopyDirectoryRecursively(DevCertsDirectory, CertsDirectory);
                }
                else
                {
                    throw new NotImplementedException();
                }
            });
        
        public static Target CleanCertificates => _ => _
            .Executes(() =>
            {
                if (EnvironmentIs(Development))
                {
                    if (DirectoryExists(CertsDirectory))
                        DeleteDirectory(CertsDirectory);
                }
                else
                {
                    throw new NotImplementedException();
                }
            });
    }
}