using System;
using Nuke.Common;
using Nuke.Common.IO;
using static Nuke.Common.IO.FileSystemTasks;
using static MyCompany.ECommerce.Nuke.Environment;
using static MyCompany.ECommerce.Nuke.Paths;

namespace MyCompany.ECommerce.Nuke.Certs
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
                    if (!CertsDirectory.DirectoryExists())
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
                    if (CertsDirectory.DirectoryExists())
                        DeleteDirectory(CertsDirectory);
                }
                else
                {
                    throw new NotImplementedException();
                }
            });
    }
}