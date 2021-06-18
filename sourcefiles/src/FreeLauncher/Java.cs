using System;
using System.IO;

namespace FreeLauncher
{
    internal static class Java
    {
        public static string JavaExecutable => JavaFolder == null ? null : string.Format("{0}\\bin\\java.exe", JavaFolder);
        public static string JavaInstallationPath => JavaFolder;

        private static string JavaFolder => $"./Java/{Forms.LauncherForm.WhichJavaVersion}/Windows_{Forms.LauncherForm.WhichBit}";

        public static bool IsJavaDownloaded
        {
            get
            {
                if (File.Exists($"./Java/{Forms.LauncherForm.WhichJavaVersion}/Windows_{Forms.LauncherForm.WhichBit}/bin/java.exe"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
